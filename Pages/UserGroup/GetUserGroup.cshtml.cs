using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS {
    public class GetUserGroupModel : PageModel {
        [BindProperty]
        public IEnumerable<UserGroup>? UserGroups { get; set; }
        [BindProperty]
        public Group? Group { get; set; }

        private IGroupService groupService;
        IUserGroupService service;
        public GetUserGroupModel(
            IUserGroupService service,
            IGroupService groupService)
        {
            this.groupService = groupService;
            this.service = service;
        }

        public IActionResult OnGet(){
            UserGroups = service?.GetUserGroups()?.ToList();

            return Page();
        }

        public Group GetGroup(int groupID){
            Group? getGroup = groupService.GetGroupById(groupID);
            if(getGroup == null){
                throw new ArgumentNullException("Group is null");
            }
            return getGroup;
        }
    }
}
