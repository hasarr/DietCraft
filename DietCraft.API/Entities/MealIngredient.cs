using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DietCraft.API.Entities
{
    [Index(nameof(IngredientId), nameof(MealId), IsUnique = true)]
    public class MealIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int IngredientId { get; set; }

        [ForeignKey("MealId")]
        [Required]
        public Meal Meal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int MealId { get; set; } 

        [Required]
        public bool IsOptional {  get; set; }

        [AllowNull]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal Grams {  get; set; }

        [AllowNull]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal Mililiters { get; set;}

        [Required]
        public int Quantity { get; set;}

    }
}
