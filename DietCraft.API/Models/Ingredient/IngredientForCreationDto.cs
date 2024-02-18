using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Ingredient
{
    public class IngredientForCreationDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        public int Kcal { get; set; } 

        [Required]
        public int ProteinGram { get; set; } 

        [Required]
        public int CarbGram { get; set; } 

        [Required]
        public int FatGram { get; set; } 
    }
}
