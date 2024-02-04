using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using DietCraft.API.Enums;

namespace DietCraft.API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DietCraftContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(DietCraftContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<(IEnumerable<User>, PaginationMetadata)> GetUsersAsync(int pageNumber, int pageSize)
        {
            var collection = _context.Users as IQueryable<User>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }
        
        public async Task<User?> GetUserByNameAsync(string userName)
        {
            var userExists = await UserExistsAsync(userName);
            if (!userExists) 
                return null; 

            var user = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> VerifyCredentialsAsync(string userName, string password)
        {
            if(await UserExistsAsync(userName))
            {
                var user = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
                return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            }

            return false;
        }

        public string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await _context.Users.AnyAsync(c => c.UserName == userName);
        }

        public void AddUserAsync(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task LoginUserAsync(User user, string password, bool rememberMe)
        {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role, RoleNumber.User.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = rememberMe,
                    ExpiresUtc = rememberMe ? System.DateTime.UtcNow.AddDays(30) : (DateTime?)null
                };

                await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task LogoutUserAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public async Task<User> GetLoggedInUserAsync()
        {
            var usernameClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name);
            if (usernameClaim == null)
                return null;

            var user = await GetUserByNameAsync(usernameClaim.Value);

            if(user == null) return null;
                return user;
        }

        public bool VerifyUserSession()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
