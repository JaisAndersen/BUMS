using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    public class GetUserModel : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IEnumerable<User> Users { get; set; }

        IUserService service { get; set; }

        public GetUserModel(IUserService service){
            this.service = service;
        }
        public int GId { get; set; }

        public void OnGet(int gid)
        {
            GId = gid;
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Users = service.GetUser(FilterCriteria);
            }
            else
            {
                Users = service.GetUser();
            }
        }
    }
}
