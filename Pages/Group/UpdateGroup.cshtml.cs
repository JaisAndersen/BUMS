using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Services.Interfaces;

namespace BUMS
{
    public class UpdateGroupModel : PageModel
    {
        [BindProperty]
        public Group Group { get; set; }
        private IGroupService service;

        public UpdateGroupModel(IGroupService service)
        {
            this.service = service;
        }
        public IActionResult OnGet(int Id)
        {
            Group = service.GetGroupById(Id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateGroup(Group, Group.GroupName);
            return RedirectToPage("GetGroup");
        }
    }
}
