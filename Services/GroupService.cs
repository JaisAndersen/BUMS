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
        public void DeleteGroup(Group group)
        {
            if (group != null)
            {
                context.Groups.Remove(group);
                context.SaveChanges();
            }
        }
        public IEnumerable<Group> FilterGroupByName(string filter)
        {
            return context.Groups.Where(g => g.GroupName.Contains(filter));
        }
        public IEnumerable<Group> GetGroup()
        {
            return context.Groups;
        }   
        public Group GetGroupById(int ID)
        {
            return context.Groups.Find(ID);
        }
        public void UpdateGroup(Group group, string GroupName)
        {
            using (var context = new BUMSDbContext())
            {
                var entity = context.Groups.FirstOrDefault(item => item.GroupId == group.GroupId);
                if (entity != null)
                {
                    entity.GroupName = GroupName;
                    context.SaveChanges();
                }
            }
        }
        public List<Access> GetAllAccess()
        {
            return context.Accesss.ToList();
        }
    }
}
