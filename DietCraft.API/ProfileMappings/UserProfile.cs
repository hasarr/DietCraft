using AutoMapper;
using DietCraft.API.Models.User;

namespace DietCraft.API.ProfileMappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Entities.User, UserDto>();
            CreateMap<UserForCreationDto, Entities.User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
