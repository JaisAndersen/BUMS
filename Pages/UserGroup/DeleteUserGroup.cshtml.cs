using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace BUMS{
    [Authorize]
    public class DeleteUserGroupModel : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);


        private IUserGroupService service;
        private IUserService userService;
        private BUMSDbContext context;
        private UserManager<User> userManager;

        [BindProperty]
        public UserGroup? UserGroup { get; set; }
        [BindProperty]
        public User? User {get;set;}

        public DeleteUserGroupModel(
                IUserGroupService service,
                IUserService userService,
                BUMSDbContext context,
                UserManager<User> userManager){
            this.context = context;
            this.userManager = userManager;
            this.userService = userService;
            this.service = service;
        }

        public async Task<IActionResult> OnGet(int id){
            if (!IsAdmin) return Forbid();

            UserGroup = await service.GetUserGroupByID(id);

            return Page();
        }

        public async Task<RedirectToPageResult> OnPost(int id){
            UserGroup = await service.GetUserGroupByID(id);
            User = userService.GetUserById(UserGroup.UserID);

            var claims = await userManager.GetClaimsAsync(User);
            var result = await userManager.RemoveClaimsAsync(User, claims);

            await service.DeleteUserGroupAsync(UserGroup);

            return new RedirectToPageResult("GetUserGroup");
        }
    }
}
