using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class CreateUserModel : PageModel
    {
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        private IUserStore<User> userStore;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        [BindProperty]
        public User? User { get; set; }

        public string Creator { get; set; }

        IUserService service;
        public CreateUserModel(
            IUserService service,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userStore = userStore;
            this.service = service;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();   
        }
        public async Task<IActionResult> OnPost()
        {
            if (!IsAdmin) return Forbid();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                User.CreatedAt = DateTime.Now;
                User.CreatedBy = "System";

                await userStore.SetUserNameAsync(User, User.UserName, CancellationToken.None);
                await userManager.AddPasswordAsync(User,User.Password);
                //await signInManager.SignInAsync(User,isPersistent:false);
                await service.AddUserAsync(User);
            }            
            return RedirectToPage("GetUser");
        }
    }
}
