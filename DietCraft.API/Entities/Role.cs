using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietCraft.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id {  get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
