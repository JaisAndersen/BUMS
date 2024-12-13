using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class CreateUserModel : PageModel
    {
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);
        [BindProperty]
        public User? User { get; set; }

        IUserService service;
        public CreateUserModel(IUserService service)
        {
            this.service = service;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                User.CreatedAt = DateTime.Now;
                User.CreatedBy = HttpContext.User.Identity.Name;
                User.EmailConfirmed = true;
                service.AddUser(User);
            }            
            return RedirectToPage("GetUser");
        }      
    }
}
