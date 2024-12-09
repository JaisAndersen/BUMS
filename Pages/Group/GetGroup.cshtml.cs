using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Services.Interfaces;

namespace BUMS{
    public class GetGroupModel : PageModel
    {
        private IGroupService context;
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        

        public IEnumerable<Group> Groups { get; set; }

        public Group Group { get; set; }

        public int GId { get; set; }

        public GetGroupModel(IGroupService service)
        {
            context = service;
        }
        public void OnGet(int gid)
        {
            GId = gid;
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Groups = context.FilterGroupByName(FilterCriteria);
            }
            else
            {
                Groups = context.GetGroup();
            }                       
        }
    }
}
