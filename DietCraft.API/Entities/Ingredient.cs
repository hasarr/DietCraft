using Microsoft.EntityFrameworkCore;
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
        public int Kcal { get; set; } 

        [Required]
        public int ProteinGram { get; set; } 

        [Required]
        public int CarbGram { get; set; } 

        [Required]
        public int FatGram { get; set; } 
    }
}


