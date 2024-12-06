using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using BUMS.Services.Interfaces;

namespace BUMS
{
    public class CreateGroupModel : PageModel
    {
        [BindProperty]
        public Group Group { get; set; }
        IGroupService groupService;
        public CreateGroupModel(IGroupService service)
        {
            this.groupService = service;
        }        
        public void OnGet()
        {
        }
        public IActionResult OnPost(){
            if (!ModelState.IsValid){
                return Page();
            }
            else{

                Group.CreatedAt = DateTime.Now;
                Group.CreatedBy = 1;
                groupService.AddGroup(Group);
            }
            return RedirectToPage("GetGroup");
        }

        
    }
}
