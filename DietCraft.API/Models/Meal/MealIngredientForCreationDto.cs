using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Meal
{
    public class MealIngredientForCreationDto
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int IngredientId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int MealId { get; set; } 

        [Required]
        public bool IsOptional {  get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal? Grams {  get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal? Mililiters { get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Quantity { get; set;}
    }
}
