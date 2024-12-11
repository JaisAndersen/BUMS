using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BUMS
{
    public class GetUserGroupModel : PageModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
        IUserGroupService service;
        public GetUserGroupModel(IUserGroupService service)
        {
            this.service = service;
        }
        public void OnGet()
        {
            UserGroups = service.GetUserGroups();
        }
    }
}
