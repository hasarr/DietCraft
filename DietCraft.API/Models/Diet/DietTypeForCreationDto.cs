using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Diet
{
    public class DietTypeForCreationDto
    {
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
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int UserIdIfCustom { get; set; }
    }
}
