﻿using DietCraft.API.Entities;

namespace DietCraft.API.Services.UserService
{
    public interface IUserRepository
    {
        public string HashPassword(string password);
        public Task<(IEnumerable<User>, PaginationMetadata)> GetUsersAsync(int pageNumber, int pageSize);
        public Task<User?> GetUserByNameAsync(string userName);
        public Task<bool> VerifyCredentialsAsync(string username, string password);
        public Task<bool> UserExistsAsync(string userName);
        public Task<bool> UserExistsAsync(int userId);
        public void AddUser(User user);
        public void DeleteUser(User user);
        public Task LoginUserAsync(User user, string password, bool rememberMe);
        public Task<User> GetLoggedInUserAsync();
        public Task LogoutUserAsync();
        public bool VerifyUserSession();
    }
}
