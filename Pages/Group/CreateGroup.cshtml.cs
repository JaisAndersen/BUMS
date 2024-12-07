using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using BUMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlTypes;

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
        public IActionResult OnPost(){
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Group.CreatedAt = DateTime.Now;
                Group.CreatedBy = 1;
                Group.AccessID = 1;
                service.AddGroup(Group);
            }
            return RedirectToPage("GetGroup");
        }

        
    }
}
