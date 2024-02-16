using AutoMapper;

namespace DietCraft.API.ProfileMappings
{
    public class MealProfile : Profile
    {
        public MealProfile() 
        { 
            CreateMap<Entities.Meal, Models.Meal.MealDto>();
            CreateMap<Models.Meal.MealForCreationDto, Entities.Meal>();
            CreateMap<Models.Meal.MealForUpdateDto, Entities.Meal>();
        }
    }
}
