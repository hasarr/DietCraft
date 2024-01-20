using DietCraft.API.Entities;

namespace DietCraft.API.Services
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetRolesAsync();
    }
}
