using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class GroupService : IGroupService
    {
        BUMSDbContext context;
        public GroupService(BUMSDbContext service)
        {
            context = service;
        }
        public void AddGroup(Group? group)
        {
            context?.Groups?.Add(group);
            context?.SaveChanges();
        }
        public void DeleteGroup(Group? group)
        {
            if (group != null)
            {
                context?.Groups?.Remove(group);
                context?.SaveChanges();
            }
        }
        public IEnumerable<Group?>? FilterGroupByName(string? filter)
        {
            return context.Groups?.Where(g => g.GroupName.Contains(filter));
        }
        public IEnumerable<Group?>? GetGroup()
        {
            return context?.Groups;
        }   
        public Group? GetGroupById(int? id)
        {
            Group? group = context?.Groups?
                .Include(s => s.UserGroups).ThenInclude(n=>n.User)
                .AsNoTracking()
                .FirstOrDefault(m=>m.GroupID == id);
            return group;
        }
        public void UpdateGroup(Group? group, string? groupName)
        {
            using (context)
            {
                var entity = context?.Groups.FirstOrDefault(item => item.GroupID == group.GroupID);
                if (entity != null)
                {
                    entity.GroupName = groupName;
                    context?.SaveChanges();
                }
            }
        }
        public List<Access?>? GetAllAccess()
        {
            return context?.Access?.ToList();
        }
        public User? GetUserById(int? ID)
        {
            //return context.Groups.FirstOrDefault(u => u.UserGroups.FirstOrDefault(c=>c.UserID == ID));
            throw new NotImplementedException();
        }
    }
}
