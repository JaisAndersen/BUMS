using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace BUMS{
    [Authorize]
    public class UpdateGroupModel : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty]
        public Group? Group { get; private set; }

        [BindProperty]
        public string? UpdatedName {get;set;}

        private readonly IGroupService service;

        public UpdateGroupModel(IGroupService service){
            this.service = service;
        }

        public IActionResult OnGet(int id){
            if (!IsAdmin) return Forbid();

            Group = service.GetGroupById(id);

            return Page();
        }

        public IActionResult OnPost(int id){
            if (!ModelState.IsValid){
                return Page();
            }

            Group = service.GetGroupById(id);

            service.UpdateGroup(Group, Group?.GroupName, HttpContext?.User?.Identity?.Name);

            return new RedirectToPageResult("GetGroup");
        }
    }
}
