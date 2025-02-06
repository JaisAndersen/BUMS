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
            IUserStore<User?>? userStore,
            UserManager<User?>? userManager,
            SignInManager<User?>? signInManager,
            IConfiguration? configuration): PageModel{

        IUserService? Service => service;
        IUserStore<User?>? UserStore => userStore;
        UserManager<User?>? UserManager => userManager;
        SignInManager<User?>? SignInManger => signInManager;
        IConfiguration? Configuration => configuration;

        [BindProperty]
        public User? UserModel { get; set; }

        public string Creator { get; set; }

        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public IList<AuthenticationScheme?>? ExternalLogins { get;private set; }


        public async Task<IActionResult> OnGetAsync(){
            if (!IsAdmin) return Forbid();

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return Page();   
        }

        public async Task<IActionResult> OnPost(){
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid){
                return Page();
            }
            else{
                var result = await userManager.CreateAsync(UserModel, UserModel.Password);

                if(result.Succeeded){
                    Bools(UserModel);
                    UserModel.UserNavigationID = AddUserNavID();

                    UserModel.CreatedAt = DateTime.Now;
                    UserModel.CreatedBy = HttpContext?.User?.Identity?.Name;

                    await userStore.SetUserNameAsync(UserModel, UserModel.UserName, CancellationToken.None);
                    await userManager.AddPasswordAsync(UserModel,UserModel.Password);

                    //await signInManager.SignInAsync(UserModel,isPersistent:false);
                    //await service.AddUserAsync(UserModel);

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
        }

        private int AddUserNavID(){
            List<User?>? users = service?.GetUsers()?.ToList();
            List<int> navIds = new List<int>();

            foreach(User? user in users){
                navIds.Add(user.UserNavigationID);
            }
            int newNavId = navIds.Max();
            return newNavId + 1;
        }

        private static void Bools(User? user){
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
        }
    }
}
