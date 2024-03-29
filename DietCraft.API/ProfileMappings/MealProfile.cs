﻿using AutoMapper;

namespace DietCraft.API.ProfileMappings
{
    public class MealProfile : Profile
    {
        public MealProfile() 
        { 
            CreateMap<Entities.Meal, Models.Meal.MealDto>();
            CreateMap<Models.Meal.MealForCreationDto, Entities.Meal>();
            CreateMap<Models.Meal.MealForUpdateDto, Entities.Meal>();

            CreateMap<Entities.MealIngredient, Models.Meal.MealIngredientDto>();
            CreateMap<Models.Meal.MealIngredientForCreationDto, Entities.MealIngredient>();
            CreateMap<Models.Meal.MealIngredientForUpdateDto, Entities.MealIngredient>();
        }
    }
}
