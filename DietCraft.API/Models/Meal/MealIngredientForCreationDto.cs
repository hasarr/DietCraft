using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Meal
{
    public class MealIngredientForCreationDto
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int IngredientId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int MealId { get; set; }

        [Required]
        public bool IsOptional {  get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public double Grams {  get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public double Mililiters { get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int Quantity { get; set;}
    }
}
