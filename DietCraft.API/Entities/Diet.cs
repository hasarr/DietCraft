using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
    public class Diet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public int DietTypeId { get; set; }

        [Required]
        public DietType DietType { get; set; }

        [Required]
        public bool isCustom { get; set; }

        public int UserIdIfCustomDiet { get; set; } = 0;

    }
}
