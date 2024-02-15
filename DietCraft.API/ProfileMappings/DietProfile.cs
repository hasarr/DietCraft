using AutoMapper;

namespace DietCraft.API.ProfileMappings
{
    public class DietProfile : Profile
    {
        public DietProfile() 
        {
            CreateMap<Entities.Diet, Models.Diet.DietDto>();
            CreateMap<Models.Diet.DietForCreationDto, Entities.Diet>();
            CreateMap<Models.Diet.DietForUpdateDto, Entities.Diet>();

            CreateMap<Entities.DietType, Models.Diet.DietTypeDto>();
        }
    }
}