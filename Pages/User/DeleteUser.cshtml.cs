using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class DeleteUserModel : PageModel
    {
        [BindProperty]
        public User? user { get; set; }

        IUserService service;

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
            service.DeleteUser(user);

            return RedirectToPage("GetUser");
        }
    }
}