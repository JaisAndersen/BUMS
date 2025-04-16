using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BUMS{
    [Authorize]
    public class CreateGroupModel(IGroupService service,BUMSDbContext context) : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        private IGroupService Service => service;
        private BUMSDbContext Context => context;

        [BindProperty]
        public Group? Group { get; set; }
        [BindProperty]
        public int SelectedValue { get; set; }

        public SelectList? SelectListAccess {get;set;}

        public List<Access>? Accesses {get;set;}

        public IActionResult OnGet(){
            Accesses = context?.Access?.ToList();
            SelectListAccess = new SelectList(Accesses,"AccessID","AccessName");
            SelectedValue = 0;

            return Page();
        }

        public IActionResult OnPost(Group group){
            if (!IsAdmin) return Forbid();

            if (!ModelState.IsValid){
                return Page();
            }

            group.CreatedAt = DateTime.Now;
            group.CreatedBy = HttpContext.User?.Identity?.Name;
            group.AccessID = SelectedValue;

            service.AddGroup(group);
            return new RedirectToPageResult("GetGroup");
        }
    }
}
