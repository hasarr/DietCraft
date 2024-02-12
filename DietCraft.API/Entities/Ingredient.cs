using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Entities
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        public int Kcal { get; set; } // Kalorie

        [Required]
        public int ProteinGram { get; set; } // Białko w gramach

        [Required]
        public int CarbGram { get; set; } // Węglowodany w gramach

        [Required]
        public int FatGram { get; set; } // Tłuszcze w gramach
    }
}


