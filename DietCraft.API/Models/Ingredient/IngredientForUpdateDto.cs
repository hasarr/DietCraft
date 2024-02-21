using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Ingredient
{
    public class IngredientForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int Kcal { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int ProteinGram { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int CarbGram { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int FatGram { get; set; } 
    }
}
