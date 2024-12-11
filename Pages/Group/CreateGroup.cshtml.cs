using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BUMS
{
    public class CreateGroupModel : PageModel
    {
        [BindProperty]
        public Group Group { get; set; }
        private IGroupService service;
        private BUMSDbContext context;

        public SelectList SelectListAccess {get;set;}

        public CreateGroupModel(IGroupService service, BUMSDbContext context)
        {
            this.context = context;
            this.service = service;
            
            SelectListAccess = new SelectList(context.Accesss, "AccessID","AccessName",selectedValue: typeof(Access));
        }        
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(Group group){
            if (!ModelState.IsValid)
            {
                return Page();
            }
            group.CreatedAt = DateTime.Now;
            group.CreatedBy = 1;
            group.AccessID = 1;
            service.AddGroup(group);
            return RedirectToPage("GetGroup");
        }

        
    }
}
