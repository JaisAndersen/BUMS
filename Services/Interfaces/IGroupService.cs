namespace BUMS
{
    public interface IGroupService
    {
        IEnumerable<Group?>? GetGroup();
        void AddGroup(Group? group);
        void DeleteGroup(Group? group);
        public Group GetGroupById(int? ID);
        public IEnumerable<Group?>? FilterGroupByName(string? filter);
        public void UpdateGroup(Group? group, string? groupName, string? updatedBy);
        public List<Access?>? GetAllAccess();
    }
}
