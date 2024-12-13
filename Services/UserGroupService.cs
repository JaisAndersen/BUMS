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
        public IEnumerable<UserGroup?>? GetUserGroups()
        {
            return context?.UserGroups.Include(s => s.User).AsNoTracking();
        }
        public void AddUserGroup(UserGroup? userGroup)
        {
            context?.UserGroups?.Add(userGroup);
            context?.SaveChanges();
        }
        public bool IsUserInGroup(User? user, Group? group, UserGroup? userGroup){
            UserGroup? checkUG = new UserGroup() { UserID = user.Id, GroupID = group.GroupID };

            List<UserGroup?>? userGroups = GetUserGroups().ToList();

            foreach (UserGroup? ug in userGroups)
            {
                if (ug.Group?.GroupID == checkUG.Group?.GroupID && ug.UserID == checkUG.UserID)
                    return true;
            }
            return false;
        }
    }
}
