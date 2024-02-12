using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Entities
{
    public class ShoppingListIngredients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int ShoppingListId { get; set; }
    
        public int IngredientId { get; set; }

        [ForeignKey("ShoppingListId")]
        public ShoppingList ShoppingList { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }
    }
}
