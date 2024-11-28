using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using BUMS.Services;
using BUMS.Services.Interfaces;
using Azure.Identity;

namespace BUMS.Pages.Group
{
    public class CreateGroupModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Models.Group Group { get; set; }
        IGroupService groupService;
        public CreateGroupModel(IGroupService service)
        {
            this.groupService = service;
        }
        public IActionResult OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            groupService.AddGroup(Group);
            Group.CreatedAt = DateTime.Now;
            Group.CreatedBy = 1;
            return RedirectToPage("GetGroup");
        }
    }
}
