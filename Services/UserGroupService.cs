using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class UserGroupService : IUserGroupService{
        BUMSDbContext context;

        public UserGroupService(BUMSDbContext service){
            context = service;
        }

        public async Task<UserGroup?> GetUserGroupByID(int id){
                UserGroup? userGroup = await context?.UserGroups?
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.UserGroupID == id);
            return userGroup;
        }

        public IEnumerable<UserGroup?>? GetUserGroups(){
            return context?.UserGroups?.Include(s => s.User).AsNoTracking();
        }

        public void AddUserGroup(UserGroup? userGroup){
            context?.UserGroups?.Add(userGroup);
            context?.SaveChanges();
        }
        
        public async Task<IActionResult> DeleteUserGroupAsync(UserGroup? userGroup){
            context?.UserGroups.Remove(userGroup);
            await context?.SaveChangesAsync();
            return null;
        }

        public async Task<IActionResult> AddUserGroupAsync(UserGroup? userGroup){
            context?.UserGroups?.Add(userGroup);
            await context?.SaveChangesAsync();
            return null;
        }
    }
}
