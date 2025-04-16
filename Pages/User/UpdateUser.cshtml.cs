using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    [Authorize]
    public class UpdateUserModel(IUserService service) : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty]
        public new User? User { get; set; }
        private IUserService Service => service;

        public IActionResult OnGet(string id){
            if (!IsAdmin) return Forbid();

            User = Service.GetUserById(id);

            return Page();
        }

        public IActionResult OnPost(){
            if(User != null){
                Service.UpdateUser(User, User.UserName, HttpContext?.User?.Identity?.Name);
            }

            return new RedirectToPageResult("GetUser");
        }
    }
}
