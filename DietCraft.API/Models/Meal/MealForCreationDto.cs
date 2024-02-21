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
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int UserIdIfCustom {  get; set; } 
    }
}
