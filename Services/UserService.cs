using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class UserService(BUMSDbContext context) : IUserService{
        private BUMSDbContext Context => context;

        public void AddUser(User? user){
            user.UserNavigationID = GetUsers().ToList().Count() + 1;
            Bools(user);

            Context?.Users?.Add(user);
            Context?.SaveChanges();
        }

        public User? GetUserById(string? id){
            User? user = Context?.Users?
                .Include(u => u.UserGroup).ThenInclude(g => g.Group)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
            return user;
        }

        public void DeleteUser(User? user){
            if (user != null){
                Context?.Users?.Remove(GetUserById(user.Id));
                Context?.SaveChanges();
            }
        }

        public IEnumerable<User?>? GetUser(string? filter){
            return Context.Set<User>().Where(s => s.UserName.Contains(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<User?>? GetUsers(){
            return Context?.Users;
        }

        public void UpdateUser(User? user, string? userName, string? updatedBy){
            using(Context){
                var updateUser = Context?.Users?.FirstOrDefault(u => u.Id == user.Id);

                if (updateUser != null){
                    updateUser.UserName = userName;
                    updateUser.Email = user.Email;
                    updateUser.UpdatedAt = DateTime.Now;
                    updateUser.UpdatedBy = updatedBy;

                    Context?.SaveChanges();
                }
            }
        }

        private static void Bools(User? user){
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
        }
    }
}

