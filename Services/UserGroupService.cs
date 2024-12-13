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
            return context?.UserGroups.Include(s => s.User);
        }
        public void AddUserGroup(UserGroup? userGroup)
        {
            context?.UserGroups?.Add(userGroup);
            context?.SaveChanges();
        }
        public bool IsUserInGroup(User? user, Group? group, UserGroup? userGroup){
            UserGroup? checkUG = new UserGroup() { User = user, Group = group };
            checkUG.User.UserNavigationID = user.UserNavigationID;
            checkUG.Group.GroupID = group.GroupID;


            List<UserGroup?>? userGroups = GetUserGroups().ToList();

            foreach (UserGroup? ug in userGroups)
            {
                if (ug.Group?.GroupID == checkUG.Group?.GroupID && ug.User?.UserNavigationID == checkUG.User?.UserNavigationID)
                    return true;
            }

            return false;
        }
    }
}
