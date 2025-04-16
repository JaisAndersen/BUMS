using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BUMS{
    [Authorize]
    public class CreateUserModel(
            IUserService? service,
            IUserStore<User>? userStore,
            UserManager<User>? userManager,
            SignInManager<User>? signInManager,
            IConfiguration? configuration): PageModel{

        IUserService? Service => service;
        IUserStore<User>? UserStore => userStore;
        UserManager<User>? UserManager => userManager;
        SignInManager<User>? SignInManger => signInManager;
        IConfiguration? Configuration => configuration;

        [BindProperty]
        public User? UserModel { get; set; }

        public string? Creator { get; set; }

        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public IList<AuthenticationScheme>? ExternalLogins { get;private set; }


        public async Task<IActionResult> OnGetAsync(){
            if (!IsAdmin) return Forbid();

            if(signInManager != null){
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            }

            return Page();   
        }

        public async Task<IActionResult> OnPost(){
            if(userManager == null){
                throw new ArgumentNullException("UserManager is null");
            }
            if(userStore == null){
                throw new ArgumentNullException("UserStore is null");
            }
            if(UserModel == null){
                throw new ArgumentNullException("User is null");
            }
            if(signInManager != null){
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            }

            if (!ModelState.IsValid){
                return Page();
            }
            else{
                if(!string.IsNullOrEmpty(UserModel.Password)){
                    var result = await userManager.CreateAsync(UserModel, UserModel.Password);

                if(result.Succeeded){
                    Bools(UserModel);
                    UserModel.UserNavigationID = AddUserNavID();

                    UserModel.CreatedAt = DateTime.Now;
                    UserModel.CreatedBy = HttpContext?.User?.Identity?.Name;

                    await userStore.SetUserNameAsync(UserModel, UserModel.UserName, CancellationToken.None);
                    await userManager.AddPasswordAsync(UserModel,UserModel.Password);

                    string adminEmail = Configuration?["AdminEmail"] ?? string.Empty;
                    bool isAdmin = string.Compare(UserModel.Email, adminEmail, true) == 0 ? true : false;
                    await userManager.AddClaimAsync(UserModel, new Claim("IsAdmin",isAdmin.ToString()));
                }
                else{
                    foreach(var error in result.Errors){
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
                return RedirectToPage("GetUser");
                }
                else{
                    ModelState.AddModelError(string.Empty, "Password is required");
                    return Page();
                }
            }            
        }

        private int AddUserNavID(){
            List<User>? users = service?.GetUsers()?.ToList();
            List<int> navIds = new List<int>();

            if(users != null){
                foreach(User? user in users){
                    navIds.Add(user.UserNavigationID);
                }
                int newNavId = navIds.Max();
                return newNavId + 1;
            }
            else{
                return 0;
            }
        }

        private static void Bools(User? user){
            if(user != null){
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = false;
                user.TwoFactorEnabled = false;
            }
        }
    }
}
