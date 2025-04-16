using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace BUMS{
    [Authorize]
    public class DeleteGroupModel : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty]
        public Group? Group { get; set; }

        [BindProperty]
        public new User? User {get;set;}

        [BindProperty]
        public List<UserGroup>? UserGroups {get;set;}

        private readonly IGroupService service;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public DeleteGroupModel(
                IGroupService service,
                IUserService userService,
                UserManager<User> userManager){
            this.userManager = userManager;
            this.userService = userService;
            this.service = service;

            UserGroups = Group?.UserGroups?.ToList();
        }

        public IActionResult OnGet(int id){
            if (!IsAdmin) return Forbid();
            Group = service.GetGroupById(id);
            return Page();
        }

        public async Task<RedirectToPageResult> OnPost(){
            if(UserGroups != null){
                foreach(UserGroup ug in UserGroups){
                    User? user = userService.GetUserById(ug.UserID);
                    if(user != null){
                        var claims = await userManager.GetClaimsAsync(user);
                        var result = await userManager.RemoveClaimsAsync(user, claims);
                    }
                }

                service.DeleteGroup(Group);
            }

            return new RedirectToPageResult("GetGroup");
        }
    }
}
