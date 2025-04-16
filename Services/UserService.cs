using Microsoft.EntityFrameworkCore;

namespace BUMS{
    public class UserService(BUMSDbContext context) : IUserService{
        private BUMSDbContext Context => context;

        public void AddUser(User? user){
            if(user == null){
                throw new ArgumentNullException("User was null");
            }

            user.UserNavigationID = GetUsers().ToList().Count() + 1;
            Bools(user);

            Context?.Users?.Add(user);
            Context?.SaveChanges();
        }

        public User? GetUserById(string? id){
            if(Context == null){
                throw new ArgumentNullException("Context is null");
            }
            if(Context.Users == null){
                throw new ArgumentNullException("Context.Users is null");
            }
            User? user = Context.Users
                .Include(u => u.UserGroup)
                .ThenInclude(g => g.Group)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
            return user;
        }

        public void DeleteUser(User? user){
            if(Context == null){
                throw new ArgumentNullException("Context is null");
            }
            if(Context.Users == null){
                throw new ArgumentNullException("Context.Users is null");
            }
            if(user == null){
                throw new ArgumentNullException("Context.Users is null");
            }
            User? userToDelete = GetUserById(user.Id);
            if(userToDelete != null){
                Context.Users.Remove(userToDelete);
                Context.SaveChanges();
            }
            else{
                throw new ArgumentNullException("User is not found");
            }
        }

        public IEnumerable<User>? GetUser(string? filter){
            if(filter != null){
                return Context.Set<User>().Where(s => s.UserName != null && s.UserName.Contains(filter)).AsNoTracking().ToList();
            }
            else{
                return null;
            }
        }

        public IEnumerable<User> GetUsers(){
            if(Context == null){
                throw new ArgumentNullException("Context is null");
            }
            if(Context.Users == null){
                throw new ArgumentNullException("Context.Users is null");
            }
            return Context.Users;
        }

        public void UpdateUser(User? user, string? userName, string? updatedBy){
            if(user != null){
                using(Context){
                    var updateUser = Context?.Users?.FirstOrDefault(u => u.Id == user.Id);

                    if (updateUser != null && user != null){
                        updateUser.UserName = userName;
                        updateUser.Email = user.Email;
                        updateUser.UpdatedAt = DateTime.Now;
                        updateUser.UpdatedBy = updatedBy;

                        Context?.SaveChanges();
                    }
                }
            }
        }

        private static void Bools(User? user){
            if(user != null){
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = false;
                user.TwoFactorEnabled = false;
            }
        }
    }
}

