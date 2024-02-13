using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services.UserService
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DietCraftContext _context;

        public RoleRepository(DietCraftContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.OrderByDescending(r => r.Id).ToListAsync();
        }
    }
}
