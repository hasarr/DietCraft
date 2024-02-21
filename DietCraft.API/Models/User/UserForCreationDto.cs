using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.User
{
    public class UserForCreationDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int RoleId { get; set; }
    }
}
