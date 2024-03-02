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
            CreateMap<Models.Diet.DietTypeForUpdateDto, Entities.DietType>();
            CreateMap<Models.Diet.DietTypeForCreationDto, Entities.DietType>();

            CreateMap<Models.Diet.UserDietForUpdateDto, Entities.UserDiet>();
            CreateMap<Models.Diet.UserDietForCreationDto, Entities.UserDiet>();
        }
    }
}