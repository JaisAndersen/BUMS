using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class UserService : IUserService{
        BUMSDbContext context;
        public UserService(BUMSDbContext service){
            context = service;
        }
        public void AddUser(User? user)
        {
            user.UserNavigationID = GetUsers().Count() + 1;
            context?.Users?.Add(user);
            context?.SaveChangesAsync();
        }
        public User? GetUserById(int? id)
        {
            User? user = context?.Users?
                .Include(u => u.UserGroup).ThenInclude(g => g.Group)
                .AsNoTracking()
                .FirstOrDefault(m => m.UserNavigationID == id);
            return user;
        }
        public void DeleteUser(User? user)
        {
            if (user != null)
            {
                context?.Users?.Remove(user);
                context?.SaveChanges();
            }
        }
        public IEnumerable<User?> GetUser(string? filter)
        {
            return this.context.Set<User>().Where(s => s.UserName.Contains(filter)).AsNoTracking().ToList();
        }
        public IEnumerable<User?>? GetUsers()
        {            
            return context?.Users;
        }

        public void UpdateUser(User? user, string? userName)
        {
                using (context)
                {
                    var entity = context?.Users?.FirstOrDefault(item => item.UserNavigationID == user.UserNavigationID);
                    if (entity != null)
                    {
                        entity.UserName = userName;
                        context?.SaveChanges();
                    }
                }
            }
        }
    }

