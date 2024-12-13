namespace BUMS
{
    public interface IUserService
    {
        public void AddUser(User? user);

        public User? GetUserById(int? ID);

        public void DeleteUser(User? user);

        public IEnumerable<User?>? GetUser(string? filter);

        public IEnumerable<User?>? GetUsers();

        public void UpdateUser(User? user, string? userName);
    }    
}
