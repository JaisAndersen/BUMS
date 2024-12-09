using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
