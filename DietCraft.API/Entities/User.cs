using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace DietCraft.API.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } 

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } 

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        public byte RoleId {  get; set; } = 1;

        [Required]
        [ForeignKey("RoleId")]
        public Role Role {  get; set; }
    }
}
