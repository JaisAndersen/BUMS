using BUMS.Pages;
using BUMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUMS{
    public class UserService : IUserService{
        BUMSDbContext context;
        public UserService(BUMSDbContext service){
            context = service;
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChangesAsync();
        }
        public User GetUserById(int ID)
        {
            return null;
            //return context.User.Find(ID);
        }
        public void DeleteUser(User user)
        {
            //if (user != null)
            //{
            //    context.User.Remove(user);
            //    context.SaveChanges();
            //}
        }
        public IEnumerable<User> GetUser(string filter)
        {
            return null;
            //return this.context.Set<User>().Where(s => s.Title.Contains(filter)).AsNoTracking().ToList();
        }
        public IEnumerable<User> GetUser()
        {
            
            return context.Users;
        }

        public void UpdateUser(User user, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
