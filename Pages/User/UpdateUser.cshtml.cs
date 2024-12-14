using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class UpdateUserModel : PageModel
    {
        [BindProperty]
        public User? user { get; set; }
        private IUserService service;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public UpdateUserModel(IUserService service)
        {
            this.service = service;
        }
        public IActionResult OnGet(string id)
        {
            user = service.GetUserById(id);
           
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (!IsAdmin) return Forbid();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateUser(user, user.UserName);
            return RedirectToPage("GetUser");
        }
    }
}

   

