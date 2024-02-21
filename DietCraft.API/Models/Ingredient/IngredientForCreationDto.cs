using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Ingredient
{
    public class IngredientForCreationDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive floating number")]
        public double Price { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int Kcal { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int ProteinGram { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int CarbGram { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int FatGram { get; set; } 
    }
}
