using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
    [Index(nameof(Name), nameof(IsCustom), nameof(UserIdIfCustom), IsUnique = true)]
    public class DietType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        public byte CarbPercent {  get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        public byte ProteinPercent {  get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        public byte FatPercent {  get; set; }

        [Required]
        public bool IsCustom { get; set; }

        [Required]
        public int UserIdIfCustom {  get; set; } = 0;
    }
}
