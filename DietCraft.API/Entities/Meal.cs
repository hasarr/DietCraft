using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Entities
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool IsVegan {  get; set; }

        [Required]
        public bool isCustom {  get; set; }

        [AllowNull]
        public int UserIdIfCustom {  get; set; }

    }
}
