using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class DeleteGroupModel : PageModel
    {
        [BindProperty]
        public Group? group { get; set; }
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        IGroupService service;

        public DeleteGroupModel(IGroupService service)
        {
            this.service = service;
        }
        public void OnGet(int id)
        {
            group = service.GetGroupById(id);
        }
        public IActionResult OnPost()
        {
            if (!IsAdmin) return Forbid();
            service.DeleteGroup(group);
            return RedirectToPage("GetGroup");
        }
    }
}
