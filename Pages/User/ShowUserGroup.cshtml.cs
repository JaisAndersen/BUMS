using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;

namespace BUMS
{
    public class ShowUserGroupModel : PageModel
    {
        IUserService service;
        public ShowUserGroupModel(IUserService service)
        {
            this.service = service;
        }
        public User User { get; set; }
        public IActionResult OnGet(int uid)
        {
            User = service.GetUserById(uid);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
