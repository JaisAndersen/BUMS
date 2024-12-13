using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class CreateUserGroupModel : PageModel
    {
        private IUserGroupService service;
        private IUserService userService;
        private IGroupService groupService;

        public string? errorMessage = "";
        [BindProperty]
        public Group? Group { get; set; }
        [BindProperty]
        public User? User { get; set; }

        [BindProperty]
        public UserGroup UserGroup { get; set; }

        public int UId { get; set; }
        public int GId { get; set; }

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
            UId = uid;
            GId = gid;

            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);

            //UserGroup = new UserGroup() { User = User, Group = Group };
        }
        public IActionResult OnPost(int uid, int gid)
        {
            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);

            UserGroup = new UserGroup() { User = User, Group = Group };
            UserGroup.GroupID = gid;
            UserGroup.UserNavigationID = uid;
            UserGroup.User.Id = User.Id;


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (!service.IsUserInGroup(User, Group, UserGroup))
            {
                service.AddUserGroup(UserGroup);
            }
            else
            {
                errorMessage = $"{User.UserName} is already a party member of {Group.GroupName}";
                return Page();
            }

            return RedirectToPage("GetUserGroup");
        }
    }
}

