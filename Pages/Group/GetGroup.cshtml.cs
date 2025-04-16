using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    public class GetGroupModel(IGroupService service) : PageModel{
        private IGroupService Service => service;
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty(SupportsGet = true)]
        public string? FilterCriteria { get; set; }

        public IEnumerable<Group>? Groups { get; set; }

        public Group? Group { get; set; }

        public int GId { get; set; }
        public string? UId { get; set; }

        public void OnGet(int gid, string uid){
            UId = uid;
            GId = gid;
            if (!String.IsNullOrEmpty(FilterCriteria)){
                Groups = service.FilterGroupByName(FilterCriteria);
            }
            else{
                Groups = service.GetGroup();
            }                       
        }
    }
}
