using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using System;

namespace BUMS
{
    public class DeleteUserModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        IUserService service;

        public DeleteUserModel(IUserService service)
        {
            this.service = service;
        }
        public void OnGet(int id)
        {
            user = service.GetUserById(id);
        }
        public IActionResult OnPost()
        {
            service.DeleteUser(user);

            return RedirectToPage("GetUser");
        }
    }
}

    

