using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class UserGroupService : IUserGroupService{
        BUMSDbContext context;

        public UserGroupService(BUMSDbContext service){
            context = service;
        }

        public async Task<UserGroup?> GetUserGroupByID(int id){
            if(context.UserGroups != null){
                UserGroup? userGroup = await context.UserGroups
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.UserGroupID == id);
                return userGroup;
            }
            else{
                return null;
            }
        }

        public IEnumerable<UserGroup>? GetUserGroups(){
            return context?.UserGroups?.Include(s => s.User).AsNoTracking();
        }

        public void AddUserGroup(UserGroup? userGroup){
            if(userGroup != null && context.UserGroups != null){
                context.UserGroups.Add(userGroup);
                context?.SaveChanges();
            }
        }
        
        public async Task<IActionResult> DeleteUserGroupAsync(UserGroup? userGroup){
            if(context == null){
                throw new ArgumentNullException("Context is null");
            }
            if(userGroup == null){
                throw new ArgumentNullException("Context is null");
            }
            if(context.UserGroups == null){
                throw new InvalidOperationException("Context.UserGroups is null");
            }

            context.UserGroups.Remove(userGroup);
            await context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IActionResult> AddUserGroupAsync(UserGroup? userGroup){
            if(context == null){
                throw new ArgumentNullException("Context is null");
            }
            if(userGroup == null){
                throw new ArgumentNullException("Context is null");
            }
            if(context.UserGroups == null){
                throw new InvalidOperationException("Context.UserGroups is null");
            }

            context.UserGroups.Add(userGroup);
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
