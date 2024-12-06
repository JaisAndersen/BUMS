using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BUMS.Models;
using BUMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUMS
{
    public class CreateUserGroupModel : PageModel
    {
        
        IUserGroupService service;
        public CreateUserGroupModel(IUserGroupService service)
        {
            this.service = service;
        }
        public void OnGet(int uid)
        {
           UserGroup.UserID = uid;
            
        }
        [BindProperty]
        public UserGroup UserGroup { get; set; } = new UserGroup();
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.AddUserGroup(UserGroup);

            return RedirectToPage("GetUserGroup");
        }
    }
}

