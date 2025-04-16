using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class GroupService(BUMSDbContext context) : IGroupService{
        BUMSDbContext Context => context;

        public void AddGroup(Group? group){
            if(group != null){
                Context?.Groups?.Add(group);
                Context?.SaveChanges();
            }
        }

        public void DeleteGroup(Group? group){
            if (group != null){
                Context?.Groups?.Remove(group);
                Context?.SaveChanges();
            }
        }

        public IEnumerable<Group>? FilterGroupByName(string? filter){
            if(filter != null){
                return Context.Groups?.Where(g => g.GroupName != null && g.GroupName.Contains(filter)).AsNoTracking();
            }
            else{
                return null;
            }
        }

        public IEnumerable<Group>? GetGroup(){
            if(Context.Groups != null){
                return Context?.Groups.AsNoTracking();
            }
            else{
                return null;
            }
        }

        public Group? GetGroupById(int id){
            Group? group = Context.Groups?
                .Include(s => s.UserGroups)
                .ThenInclude(n => n.User)
                .AsNoTracking()
                .FirstOrDefault(m => m.GroupID == id);
            return group;
        }

        public void UpdateGroup(Group? group, string? groupName, string? updatedBy){
            if(group != null){
                using(Context){
                    var entity = Context?.Groups?.FirstOrDefault(item => item.GroupID == group.GroupID);
                    if (entity != null){
                        entity.GroupName = groupName;
                        entity.UpdatedAt = DateTime.Now;
                        entity.UpdatedBy = updatedBy;
                        Context?.SaveChanges();
                    }
                }
            }
        }

        public List<Access>? GetAllAccess(){
            return Context?.Access?.ToList();
        }
    }
}
