using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            IQueryable<User> collection = _context.Users;

            var collectionToReturn = await collection.OrderBy(u => u.Id).ToListAsync();

            return collectionToReturn;
        }
        
        public async Task<User?> GetUserByNameAsync(string userName)
        {
            var userExists = await UserExists(userName);
            if (!userExists) 
                return null; 

            var user = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

            if(user != null)
                return user;

            return null;

        }

        public async Task<bool> VerifyUserAsync(string userName, string password)
        {
            if(await UserExists(userName))
            {
                var user = await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

                if(user != null)
                { 
                    return VerifyPassword(password, user.PasswordHash);
                }
               
                return false;
            }

            return false;
        }

        public string HashPassword(string password)
        {
            // GenerateSalt() generuje losową sól
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // HashPassword() używa generowanej soli do haszowania hasła
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public bool VerifyPassword(string plainTextPassword, string passwordHash)
        {
            return  BCrypt.Net.BCrypt.Verify(plainTextPassword, passwordHash);
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(c => c.UserName == userName);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if(user == null) return false;

            bool userExists = await UserExists(user.UserName);

            if (!userExists)
            {
                _context.Users.Add(user);
                return true;
            }

            return false;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> LoginUserAsync(User user, string password, bool rememberMe)
        {
            if(await VerifyUserAsync(user.UserName, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role, user.Role),
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
                return true;
                
            }

            return false;
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
