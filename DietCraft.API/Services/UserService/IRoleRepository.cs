using DietCraft.API.Entities;

namespace DietCraft.API.Services.UserService
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetRolesAsync();
    }
}
