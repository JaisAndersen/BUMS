using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BUMS{
    [Authorize]
    public class CreateUserGroupModel : PageModel{
        private readonly IUserGroupService service;
        private readonly IUserService userService;
        private readonly IGroupService groupService;
        private readonly IAccessService accessService;

        private readonly UserManager<User>? userManager;
        private readonly BUMSDbContext context;

        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public string? errorMessage = "";
        public string? groupHasAdminClaim = "";

        [BindProperty]
        public Group? Group { get; set; }
        [BindProperty]
        public new User? User { get; set; }
        [BindProperty]
        public Access? Access { get; set; }

        [BindProperty]
        public UserGroup? UserGroup { get; set; }

        public string? UId { get; set; }
        public int? GId { get; set; }

        public CreateUserGroupModel(IUserGroupService service, 
                IUserService userService, 
                IGroupService groupService,
                IAccessService accessService,
                BUMSDbContext context,
                UserManager<User> userManager){
            this.context = context;
            this.accessService = accessService;
            this.userManager = userManager;
            this.userService = userService;
            this.groupService = groupService;
            this.service = service;

        }

        public IActionResult OnGet(string? uid, int gid){
            if (!IsAdmin) return Forbid();
            UId = uid;
            GId = gid;

            Group = groupService.GetGroupById(gid);
            User = userService.GetUserById(uid);

            if(Group != null){
                switch(Group.AccessID){
                    case 1:
                        groupHasAdminClaim = $"{Group.GroupName} is an Admin group";
                        break;
                    case 2:
                        groupHasAdminClaim = $"{Group.GroupName} is an UserAdmin group";
                        break;
                    case 3:
                        groupHasAdminClaim = $"{Group.GroupName} is an User group";
                        break;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string? uid, int gid){
            if(userManager == null){
                throw new ArgumentNullException("UserManager is null");
            }
            User = userService.GetUserById(uid);
            if(User == null){
                throw new ArgumentNullException("User not found");
            }

            Group = groupService.GetGroupById(gid);
            if(Group == null){
                throw new ArgumentNullException("Group not found");
            }

            Access = accessService.GetAccessById(Group.AccessID);
            if(Access == null){
                throw new ArgumentNullException("Access not found");
            }

            List<int> groups = new List<int>();
            foreach(UserGroup? ug in User.UserGroup){
                groups.Add(ug.GroupID);
            }

            UserGroup = new UserGroup() { GroupID = gid, UserID = uid };

            if(!groups.Contains(UserGroup.GroupID)){
                await service.AddUserGroupAsync(UserGroup);

                if(Access?.AccessID == 1){
                    Claim claim = new Claim("IsAdmin", "True");
                    await userManager.AddClaimAsync(User, claim);
                }
            }
            else{
                errorMessage = $"{User.UserName} is already a member of {Group.GroupName}";
                return Page();
            }

            return RedirectToPage("GetUserGroup");
        }
    }
}

