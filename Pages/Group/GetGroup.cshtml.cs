using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using BUMS.Services.Interfaces;

namespace BUMS.Pages.Group
{
    public class GetGroupModel : PageModel
    {        
        public IEnumerable<Models.Group> Groups { get; set; }
        public Models.Group Group { get; set; }

        private IGroupService context;
        public GetGroupModel(IGroupService service)
        {
            context = service;
        }
        public void OnGet()
        {
            Groups = context.GetGroup();
        }
    }
}
