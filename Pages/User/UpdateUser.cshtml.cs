using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class UpdateUserModel : PageModel
    {
        [BindProperty]
        public User? User { get; set; }
        private IUserService service;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public UpdateUserModel(IUserService service)
        {
            this.service = service;
        }
        public IActionResult OnGet(string id)
        {
            User = service.GetUserById(id);
           
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (!IsAdmin) return Forbid();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User.UpdatedAt = DateTime.Now;
            User.UpdatedBy = HttpContext.User.Identity.Name;

            service.UpdateUser(User, User.UserName);
            return RedirectToPage("GetUser");
        }
    }
}

   

