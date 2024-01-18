using DietCraft.API.Entities;

namespace DietCraft.API.Services
{
    public interface IUserRepository
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string plainTextPassword, string passwordHash);
        public Task<IEnumerable<User>>  GetUsersAsync();
        public Task<User?> GetUserByNameAsync(string userName);
        public Task<bool> VerifyUserAsync(string username, string password);
        public Task<bool> UserExists(string userName);
        public Task<bool> AddUserAsync(User user);
        public void DeleteUser(User user);
        public Task<bool> SaveChangesAsync();
        public Task<bool> LoginUserAsync(User user, string password, bool rememberMe);
        public Task<User> GetLoggedInUserAsync();
        public Task LogoutUserAsync();
        public bool VerifyUserSession();    
    }
}
