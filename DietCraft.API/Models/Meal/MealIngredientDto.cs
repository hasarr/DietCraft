﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Models.Meal
{
    public class MealIngredientDto
    {
        public int Id { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int MealId { get; set; } 

        [Required]
        public bool IsOptional {  get; set; }

        public double Grams {  get; set; }

        public double Mililiters { get; set;}

        [Required]
        public int Quantity { get; set;}
    }
}
