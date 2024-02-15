using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DietCraft.API.Entities
{
    [Index(nameof(ShoppingListId), nameof(IngredientId), IsUnique = true)]
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
