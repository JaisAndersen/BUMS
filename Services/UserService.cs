using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BUMS
{
    public class UserService : IUserService{
        private BUMSDbContext context;
        
        public UserService(BUMSDbContext service){
            context = service;
        }
        public async Task<IActionResult> AddUserAsync(User? user)
        {
            user.UserNavigationID = GetUsers().ToList().Count() + 1;
            Bools(user);
            
            context?.Users?.AddAsync(user);
            context?.SaveChanges();
            return null;
        }
        public User? GetUserById(string? id)
        {
            User? user = context?.Users?
                .Include(u => u.UserGroup).ThenInclude(g => g.Group)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
            return user;
        }
        public void DeleteUser(User? user)
        {
            if (user != null)
            {
                context?.Users?.Remove(GetUserById(user.Id));
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
                var entity = context?.Users?.FirstOrDefault(item => item.Id == user.Id);
                if (entity != null)
                {
                    entity.UserName = userName;
                    entity.Email = user.Email;
                    context?.SaveChanges();
                }
            }
        }

        private void Bools(User? user){
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
        }
    }
}

