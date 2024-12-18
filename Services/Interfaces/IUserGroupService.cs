﻿namespace BUMS
{
    public interface IUserGroupService
    {
        public IEnumerable<UserGroup?>? GetUserGroups();
        public void AddUserGroup(UserGroup? userGroup);
        public bool IsUserInGroup(User? user, Group? group, UserGroup? userGroup);
    }
}
