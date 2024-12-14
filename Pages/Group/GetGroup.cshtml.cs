using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    
    public class GetGroupModel : PageModel
    {
        private IGroupService context;
        [BindProperty(SupportsGet = true)]
        public string? FilterCriteria { get; set; }

        public IEnumerable<Group>? Groups { get; set; }

        public Group? Group { get; set; }

        public int GId { get; set; }
        public string UId { get; set; }
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        public GetGroupModel(IGroupService service)
        {
            context = service;
        }
        public void OnGet(int gid, string uid)
        {
            UId = uid;
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
