using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace BUMS
{
    [Authorize]
    public class DeleteUserModel : PageModel
    {
        [BindProperty]
        public User? user { get; set; }

        IUserService service;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public DeleteUserModel(IUserService service)
        {
            this.service = service;
        }
        public void OnGet(string id)
        {
            user = service.GetUserById(id);
        }
        public IActionResult OnPost(string id)
        {
            if (!IsAdmin) return Forbid();
            service.DeleteUser(user);

            return RedirectToPage("GetUser");
        }
    }
}