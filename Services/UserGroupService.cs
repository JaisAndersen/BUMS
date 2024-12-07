using BUMS.Models;
using BUMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUMS.Services
{
    public class UserGroupService : IUserGroupService
    {

        BUMSDbContext context;
        public UserGroupService(BUMSDbContext service)
        {
            context = service;
        }
        public IEnumerable<UserGroup> GetUserGroups()
        {
            return context.UserGroups.Include(s => s.User);
        }
        public void AddUserGroup(UserGroup UserGroup)
        {
            context.UserGroups.Add(UserGroup);
            context.SaveChanges();
        }



    }
}
