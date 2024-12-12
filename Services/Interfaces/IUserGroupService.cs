﻿namespace BUMS.Services.Interfaces
{
    public interface IUserGroupService
    {

        public IEnumerable<UserGroup> GetUserGroups();
        public void AddUserGroup(UserGroup UserGroup);
        public User GetUserById(int id, User user);
    }
}
