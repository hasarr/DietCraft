using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Meal
{
    public class MealForUpdateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public bool IsVegan {  get; set; }
    }
}
