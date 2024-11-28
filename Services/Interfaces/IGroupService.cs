using BUMS.Models;

namespace BUMS.Services.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroup();
        void AddGroup(Group group);
    }
}
