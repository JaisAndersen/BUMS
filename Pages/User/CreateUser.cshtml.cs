using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BUMS
{
    [Authorize]
    public class CreateUserModel : PageModel
    {
        private IUserStore<User> userStore;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private IConfiguration configuration;

        [BindProperty]
        public User? User { get; set; }

        public string Creator { get; set; }

        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public IList<AuthenticationScheme> ExternalLogins { get;set; }

        IUserService service;
        public CreateUserModel(
                IUserService service,
                IUserStore<User> userStore,
                SignInManager<User> signInManager,
                UserManager<User> userManager,
                IConfiguration configuration)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userStore = userStore;
            this.service = service;
        }
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
                var result = await userManager.CreateAsync(User, User.Password);

                if(result.Succeeded){
                    User.CreatedAt = DateTime.Now;
                    User.CreatedBy = HttpContext.User.Identity.Name;

                    await userStore.SetUserNameAsync(User, User.UserName, CancellationToken.None);
                    await userManager.AddPasswordAsync(User,User.Password);

                    //await signInManager.SignInAsync(User,isPersistent:false);
                    //await service.AddUserAsync(User);

                    string adminEmail = configuration["AdminEmail"] ?? string.Empty;
                    bool isAdmin = string.Compare(User.Email, adminEmail, true) == 0 ? true : false;
                    await userManager.AddClaimAsync(User, new Claim("IsAdmin",isAdmin.ToString()));
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
    }
}
