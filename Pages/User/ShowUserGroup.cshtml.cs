using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class ShowUserGroupModel : PageModel
    {
        IUserService service;
        public ShowUserGroupModel(IUserService service)
        {
            this.service = service;
        }
        [BindProperty]
        public User User { get; set; }
        public IActionResult OnGet(string? uid)
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
