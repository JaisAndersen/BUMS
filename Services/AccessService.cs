using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class AccessService : IAccessService{
        BUMSDbContext context;
       
        public AccessService(BUMSDbContext service){
            context = service;
        }

        public void AddAccess(Access? access){
            if(access != null){
                context?.Access?.Add(access);
                context?.SaveChanges();
            }
        }

        public void DeleteAccess(Access? access){
            if (access != null){
                context?.Access?.Remove(access);
                context?.SaveChanges();
            }
        }

        public IEnumerable<Access>? FilterAccessByName(string? filter){
            if(filter != null && context.Access != null){
                return context.Access.Where(g => g.AccessName != null && g.AccessName.Contains(filter)).AsNoTracking();
            }
            else{
                return null;
            }
        }

        public IEnumerable<Access>? GetAccess(){
            if(context.Access != null){
                return context.Access.AsNoTracking();
            }
            else{
                return null;
            }
        }

        public Access? GetAccessById(int id){
            Access? access = context?.Access?
                .AsNoTracking()
                .FirstOrDefault(m => m.AccessID == id);
            return access;
        }

        public void UpdateAccess(Access? access, string? accessName){
            using (context){
                if(context.Access != null && access != null){
                    var entity = context.Access.FirstOrDefault(item => item.AccessID == access.AccessID);
                    if (entity != null)
                    {
                        entity.AccessName = accessName;
                        context?.SaveChanges();
                    }
                }
            }
        }

        public List<Access>? GetAllAccess(){
            if(context.Access != null){
                return context.Access?.ToList();
            }
            else{
                return null;
            }
        }
    }
}
