using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class AccessService : IAccessService{
        BUMSDbContext context;
       
        public AccessService(BUMSDbContext service){
            context = service;
        }

        public void AddAccess(Access? access){
            context?.Access?.Add(access);
            context?.SaveChanges();
        }

        public void DeleteAccess(Access? access){
            if (access != null)
            {
                context?.Access?.Remove(access);
                context?.SaveChanges();
            }
        }

        public IEnumerable<Access?>? FilterAccessByName(string? filter){
            return context.Access?.Where(g => g.AccessName.Contains(filter)).AsNoTracking();
        }

        public IEnumerable<Access?>? GetAccess(){
            return context?.Access.AsNoTracking();
        }

        public Access? GetAccessById(int? id){
            Access? access = context?.Access?
                .AsNoTracking()
                .FirstOrDefault(m=>m.AccessID == id);
            return access;
        }

        public void UpdateAccess(Access? access, string? accessName){
            using (context){
                var entity = context?.Access.FirstOrDefault(item => item.AccessID == access.AccessID);
                if (entity != null)
                {
                    entity.AccessName = accessName;
                    context?.SaveChanges();
                }
            }
        }

        public List<Access?>? GetAllAccess(){
            return context?.Access?.ToList();
        }
    }
}
