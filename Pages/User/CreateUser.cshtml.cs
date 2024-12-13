using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class CreateUserModel : PageModel
    {
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
                User.CreatedBy = 1;
                User.EmailConfirmed = true;
                service.AddUser(User);
            }            
            return RedirectToPage("GetUser");
        }      
    }
}
