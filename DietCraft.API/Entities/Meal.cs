using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Entities
{
    [Index(nameof(Name), nameof(IsCustom), nameof(UserIdIfCustom), IsUnique = true)]
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
        public bool IsCustom {  get; set; }

        [AllowNull]
        public int UserIdIfCustom {  get; set; }

    }
}
