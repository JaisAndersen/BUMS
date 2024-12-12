using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class CreateUserGroupModel : PageModel
    {
        private IUserGroupService service;
        private IUserService userService;
        private IGroupService groupService;

        public string errorMessage = "";
        [BindProperty]
        public Group Group { get; set; }
        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public UserGroup UserGroup { get; set; } = new UserGroup();

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
            UserGroup.GroupID = gid;
            UserGroup.UserID = uid;
            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);
            UserGroup = new UserGroup() { GroupID = gid, UserID = uid, User = User };
        }
        public IActionResult OnPost(int uid, int gid)
        {
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
                errorMessage = "Bruger findes i gruppen allerede";
                return Page();
            }

            return RedirectToPage("GetUserGroup");
        }
    }
}

