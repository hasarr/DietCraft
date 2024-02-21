using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
    [Index(nameof(DietId), nameof(UserId), IsUnique = true)]
    public class UserDiet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int DietId { get; set; }

        [ForeignKey("DietId")]
        public Diet Diet {  get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int UserId {  get; set; }

        [Required]
        public User User {  get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int MaxKcal { get; set; }
    }
}
