using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Diet
{
    public class UserDietForUpdateDto
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        [DefaultValue(0)]
        public int MaxKcal { get; set; }
    }
}
