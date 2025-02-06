using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS{
    [Authorize]
    public class GetUserModel(IUserService service) : PageModel{
        public bool IsAdmin => HttpContext.User.HasClaim("IsAdmin", bool.TrueString);

        private IUserService Service => service;

        [BindProperty(SupportsGet = true)]
        public string? FilterCriteria { get; set; }

        public int GId { get; set; }

        public IEnumerable<User?>? Users { get; set; }

        public IEnumerable<UserGroup?>? UserGroups {get;private set;}

        public ActionResult OnGet(int gid){
            GId = gid;

            if (!String.IsNullOrEmpty(FilterCriteria)){
                Users = Service.GetUser(FilterCriteria);
            }
            else{
                Users = Service.GetUsers();
            }

            return Page();
        }
    }
}
