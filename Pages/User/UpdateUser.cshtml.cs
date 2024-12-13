using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class UpdateUserModel : PageModel
    {
        [BindProperty]
        public User? user { get; set; }
        private IUserService service;

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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateUser(user, user.UserName);
            return RedirectToPage("GetUser");
        }
    }
}

   

