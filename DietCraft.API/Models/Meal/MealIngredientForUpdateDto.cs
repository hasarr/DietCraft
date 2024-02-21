using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Meal
{
    public class MealIngredientForUpdateDto
    {
        [Required]
        public bool IsOptional {  get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public decimal? Grams {  get; set; } = 0;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public decimal? Mililiters { get; set;} = 0;

        [Required]
        public int Quantity { get; set;}
    }
}
