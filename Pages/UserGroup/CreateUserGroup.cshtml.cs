using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BUMS
{
    [Authorize]
    public class CreateUserGroupModel : PageModel
    {
        private IUserGroupService service;
        private IUserService userService;
        private IGroupService groupService;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public string? errorMessage = "";
        [BindProperty]
        public Group? Group { get; set; }
        [BindProperty]
        public User? User { get; set; }

        [BindProperty]
        public UserGroup UserGroup { get; set; }

        public string? UId { get; set; }
        public int? GId { get; set; }

        public CreateUserGroupModel(IUserGroupService service, 
            IUserService userService, 
            IGroupService groupService)
        {
            this.userService = userService;
            this.groupService = groupService;
            this.service = service;

        }
        public IActionResult OnGet(string? uid, int? gid)
        {
            if (!IsAdmin) return Forbid();
            UId = uid;
            GId = gid;

            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);

            return Page();
        }
        public IActionResult OnPost(string? uid, int gid)
        {
            User = userService.GetUserById(uid);
            Group = groupService.GetGroupById(gid);

            UserGroup = new UserGroup() { GroupID = gid, UserID = uid };

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            if (User.UserGroup.Count == 0)
            {
                service.AddUserGroup(UserGroup);
            }
            else
            {
                foreach (UserGroup ug in User.UserGroup)
                {
                    if (ug.GroupID != UserGroup.GroupID)
                    {
                        service.AddUserGroup(UserGroup);
                    }

                    else
                    {
                        errorMessage = $"{User.UserName} is already a party member of {Group.GroupName}";
                        return Page();
                    }
                }
            }
            
            return RedirectToPage("GetUserGroup");
        }
    }
}

