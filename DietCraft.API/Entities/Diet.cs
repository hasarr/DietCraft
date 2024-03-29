﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Entities
{
    [Index(nameof(Name), nameof(IsCustom), nameof(UserIdIfCustom), IsUnique = true)]
    public class Diet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int DietTypeId { get; set; }

        [Required]
        [ForeignKey("DietTypeId")]
        public DietType DietType { get; set; }

        [Required]
        public bool IsCustom { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int UserIdIfCustom { get; set; } = 0;

    }
}
