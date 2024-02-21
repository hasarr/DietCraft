using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.User
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
