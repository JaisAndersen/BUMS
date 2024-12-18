using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace BUMS
{
    public class GetUserGroupModel : PageModel
    {
        [BindProperty]
        public IEnumerable<UserGroup>? UserGroups { get; set; }

        private IGroupService groupService;
        IUserGroupService service;
        public GetUserGroupModel(IUserGroupService service, IGroupService groupService)
        {
            this.groupService = groupService;
            this.service = service;
        }
        public async Task<IActionResult> OnGet()
        {
            UserGroups = service.GetUserGroups().ToList();
            return Page();
        }
        public Group GetGroup(int groupID)
        {
            Group getGroup = groupService.GetGroupById(groupID);
            return getGroup;
        }
    }
}
