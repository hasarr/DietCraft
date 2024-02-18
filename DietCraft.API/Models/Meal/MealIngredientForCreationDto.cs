﻿using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Meal
{
    public class MealIngredientForCreationDto
    {
        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int MealId { get; set; } 

        [Required]
        public bool IsOptional {  get; set; }

        public decimal? Grams {  get; set; }

        public decimal? Mililiters { get; set;}

        [Required]
        public int Quantity { get; set;}
    }
}
