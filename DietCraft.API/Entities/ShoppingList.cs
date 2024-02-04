using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Entities
{
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

        public ICollection<Ingredient> Ingredients { get; set;}
                = new List<Ingredient>();

        [Required]
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }

        [Required]
        public int MealId { get; set; } 

    }
}
