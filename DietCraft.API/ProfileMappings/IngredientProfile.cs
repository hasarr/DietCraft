using AutoMapper;

namespace DietCraft.API.ProfileMappings
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile() 
        { 
            CreateMap<Entities.Ingredient, Models.Ingredient.IngredientDto>();
            CreateMap<Models.Ingredient.IngredientForCreationDto, Entities.Ingredient>();
            CreateMap<Models.Ingredient.IngredientForUpdateDto, Entities.Ingredient>();
        }
    }
}
