using AutoMapper;
using DietCraft.API.Models.Role;

namespace DietCraft.API.ProfileMappings
{
    public class RoleProfile: Profile
    {
        public RoleProfile() 
        { 
            CreateMap<Entities.Role, Models.Role.RoleDto>();
        }
    }
}
