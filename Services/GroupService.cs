using BUMS.Models;
using BUMS.Services.Interfaces;

namespace BUMS.Services
{
    public class GroupService : IGroupService
    {
        BUMSDbContext context;
        public GroupService(BUMSDbContext service)
        {
            context = service;
        }
        public void AddGroup(Group group)
        {
            context.Groups.Add(group);
            context.SaveChanges();
        }

        public IEnumerable<Group> GetGroup()
        {
            return context.Groups;
        }
    }
}
