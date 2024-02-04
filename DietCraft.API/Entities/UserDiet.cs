using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
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
        public int UserId {  get; set; }

        [Required]
        public User User {  get; set; }

        [Required]
        public int MaxKcal { get; set; }
    }
}
