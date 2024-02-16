using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Models.Meal
{
    public class MealForCreationDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public bool IsVegan {  get; set; }

        [Required]
        public bool IsCustom {  get; set; }

        [Required]
        public int UserIdIfCustom {  get; set; } 
    }
}
