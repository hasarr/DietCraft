using DietCraft.API.Entities;

namespace DietCraft.API.Services
{
    public interface IUserRepository
    {
        public string HashPassword(string password);
        public Task<(IEnumerable<User>, PaginationMetadata)>  GetUsersAsync(int pageNumber, int pageSize);
        public Task<User?> GetUserByNameAsync(string userName);
        public Task<bool> VerifyCredentialsAsync(string username, string password);
        public Task<bool> UserExistsAsync(string userName);
        public void AddUserAsync(User user);
        public void DeleteUser(User user);
        public Task<bool> SaveChangesAsync();
        public Task LoginUserAsync(User user, string password, bool rememberMe);
        public Task<User> GetLoggedInUserAsync();
        public Task LogoutUserAsync();
        public bool VerifyUserSession();    
    }
}
