using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Models.User
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [AllowNull]
        public string Email { get; set; }
        [Required, NotNull]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
