using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    public class ShowUserGroupModel(IUserService service) : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty]
        public User? UserModel { get; set; }

        IUserService? Service => service;

        public IActionResult OnGet(string? uid){
            UserModel = Service?.GetUserById(uid);
            if (UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
