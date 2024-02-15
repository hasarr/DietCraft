using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Entities
{
    public class MealIngredients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("MealId")]
        [Required]
        public Meal Meal { get; set; }

        [Required]
        public int MealId { get; set; } 

        [Required]
        public bool IsOptional {  get; set; }

        [AllowNull]
        public decimal Grams {  get; set; }

        [AllowNull]
        public decimal Mililiters { get; set;}

        [Required]
        public int Quantity { get; set;}

    }
}
