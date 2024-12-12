using Microsoft.EntityFrameworkCore;

namespace BUMS
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
        public bool IsUserInGroup(User user, Group group, UserGroup? userGroup){
            UserGroup checkUG = new UserGroup() { UserID = user.UserID, GroupID = group.GroupId, User = user };

            List<UserGroup> userGroups = GetUserGroups().ToList();

            foreach (UserGroup ug in userGroups)
            {
                if (ug.GroupID == checkUG.GroupID && ug.UserID == checkUG.UserID)
                    return true;
            }

            return false;
        }
    }
}
