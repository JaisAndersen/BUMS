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
            UserGroup? checkUG = new UserGroup() { User = user, Group = group };

            List<UserGroup?>? userGroups = GetUserGroups().ToList();

            foreach (UserGroup? ug in userGroups)
            {
                if (ug.Group?.GroupID == checkUG.Group?.GroupID && ug.User?.Id == checkUG.User?.Id)
                    return true;
            }
            return false;
        }
    }
}
