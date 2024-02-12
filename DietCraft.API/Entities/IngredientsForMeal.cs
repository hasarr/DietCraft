using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Entities
{
    public class IngredientsForMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }

        [ForeignKey("MealId")]
        public Meal Meal { get; set; }

        public int MealId { get; set; } 

        public bool IsOptional {  get; set; }

        [AllowNull]
        public decimal Grams {  get; set; }

        [AllowNull]
        public decimal Mililiters { get; set;}

        public int Quantity { get; set;}
    }
}
