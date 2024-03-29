﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Models.Meal
{
    public class MealDto
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool IsVegan {  get; set; }

        [Required]
        public bool IsCustom {  get; set; }

        [AllowNull]
        public int UserIdIfCustom {  get; set; }
    }
}
