using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DescriptionHTML { get; set; }

        [Required]
        public string TitleHTML { get; set; }

        [Required]
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }

        [Required]
        public int MealId {  get; set; }

        [Required]
        public bool isStepByStep { get; set; }
    }
}
