using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class GroupService(BUMSDbContext context) : IGroupService{
        BUMSDbContext Context => context;

        public void AddGroup(Group? group){
            Context?.Groups?.Add(group);
            Context?.SaveChanges();
        }

        public void DeleteGroup(Group? group){
            if (group != null){
                Context?.Groups?.Remove(group);
                Context?.SaveChanges();
            }
        }

        public IEnumerable<Group?>? FilterGroupByName(string? filter){
            return Context.Groups?.Where(g => g.GroupName.Contains(filter)).AsNoTracking();
        }

        public IEnumerable<Group?>? GetGroup(){
            return Context?.Groups.AsNoTracking();
        }

        public Group? GetGroupById(int? id){
            Group? group = Context?.Groups?
                .Include(s => s.UserGroups).ThenInclude(n => n.User)
                .AsNoTracking()
                .FirstOrDefault(m => m.GroupID == id);
            return group;
        }

        public void UpdateGroup(Group? group, string? groupName, string? updatedBy){
            using(Context){
                var entity = Context?.Groups.FirstOrDefault(item => item.GroupID == group.GroupID);
                if (entity != null){
                    entity.GroupName = groupName;
                    entity.UpdatedAt = DateTime.Now;
                    entity.UpdatedBy = updatedBy;
                    Context?.SaveChanges();
                }
            }
        }

        public List<Access?>? GetAllAccess(){
            return Context?.Access?.ToList();
        }
    }
}
