using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using System.ComponentModel;

namespace BUMS
{
    public class UpdateUserModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private IUserService service;

        public UpdateUserModel(IUserService service)
        {
            this.service = service;
        }
        public IActionResult OnGet(int Id)
        {
            user = service.GetUserById(Id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateUser(user);
            return RedirectToPage("GetUser");
        }
    }
}

   

