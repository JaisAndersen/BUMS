using BUMS.Models;

namespace BUMS.Services.Interfaces
{
    public interface IUserGroupService
    {

        public IEnumerable<UserGroup> GetUserGroups();
        public void AddUserGroup(UserGroup UserGroup);

    }
}
