using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Services.Interfaces;

namespace BUMS
{
    public class CreateUserGroupModel : PageModel
    {
        private IUserGroupService service;
        private IUserService userService;
        private IGroupService groupService;

        public Group Group { get; set; }
        public User User { get; set; }

        [BindProperty]
        public UserGroup UserGroup { get; set; } = new UserGroup();

        public CreateUserGroupModel(IUserGroupService service, 
            IUserService userService, 
            IGroupService groupService)
        {
            this.userService = userService;
            this.groupService = groupService;
            this.service = service;
        }
        public void OnGet(int uid, int gid)
        {
            UserGroup.GroupID = gid;
            UserGroup.UserID = uid;
            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);
            UserGroup = new UserGroup() { GroupID = gid, UserID = uid };
        }
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            service.AddUserGroup(UserGroup);

            return RedirectToPage("GetUserGroup");
        }
    }
}

