using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DietCraft.API.Models.Diet
{
    public class UserDietForCreationDto
    {

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int DietId { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int UserId {  get; set; }


        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int MaxKcal { get; set; }
    }
}
