using AutoMapper;

namespace DietCraft.API.ProfileMappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserForCreationDto, Entities.User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        }
    }
}
