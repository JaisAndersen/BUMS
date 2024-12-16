using Microsoft.AspNetCore.Mvc;

namespace BUMS
{
    public interface IUserService
    {
        public Task<IActionResult> AddUserAsync(User? user);

        public User? GetUserById(string? ID);

        public void DeleteUser(User? user);

        public IEnumerable<User?>? GetUser(string? filter);

        public IEnumerable<User?>? GetUsers();

        public void UpdateUser(User? user, string? userName, string? updatedBy);
    }    
}
