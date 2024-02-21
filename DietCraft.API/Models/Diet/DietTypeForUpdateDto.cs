using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Diet
{
    public class DietTypeForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        [DefaultValue(0)]
        public byte CarbPercent {  get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        [DefaultValue(0)]
        public byte ProteinPercent {  get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Percent value must be 0-100")]
        [DefaultValue(0)]
        public byte FatPercent {  get; set; }
    }
}
