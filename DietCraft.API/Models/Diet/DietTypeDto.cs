using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Diet
{
    public class DietTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public byte CarbPercent {  get; set; }

        [Required]
        public byte ProteinPercent {  get; set; }

        [Required]
        public byte FatPercent {  get; set; }

        [Required]
        public bool IsCustom { get; set; }

        [Required]
        public int UserIdIfCustom { get; set; }
    }
}
