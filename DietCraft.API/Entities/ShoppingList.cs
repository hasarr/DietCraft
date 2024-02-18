using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Entities
{
    [Index(nameof(Name), nameof(UserId), IsUnique = true)]
    public class ShoppingList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId {  get; set; }

        [Required]
        public User User {  get; set; }

        public ICollection<ShoppingListIngredient> ShoppingListIngredients { get; set;}
                = new List<ShoppingListIngredient>();

    }
}
