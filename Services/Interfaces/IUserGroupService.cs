using Microsoft.AspNetCore.Mvc;
namespace BUMS
{
    public interface IUserGroupService
    {
        public IEnumerable<UserGroup?>? GetUserGroups();
        public Task<UserGroup?> GetUserGroupByID(int id);
        public void AddUserGroup(UserGroup? userGroup);
        public Task<IActionResult> DeleteUserGroupAsync(UserGroup? userGroup);
        public Task<IActionResult> AddUserGroupAsync(UserGroup? userGroup);
    }
}
