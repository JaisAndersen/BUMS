using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    [Authorize]
    public class UpdateGroupModel : PageModel
    {
        [BindProperty]
        public Group? Group { get; set; }
        private IGroupService service;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public UpdateGroupModel(IGroupService service)
        {
            this.service = service;
        }
        public IActionResult OnGet(int id)
        {
            Group = service.GetGroupById(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!IsAdmin) return Forbid();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateGroup(Group, Group.GroupName, HttpContext.User.Identity.Name);
            return RedirectToPage("GetGroup");
        }
    }
}
