﻿using System.ComponentModel.DataAnnotations;

namespace DietCraft.API.Models.Diet
{
    public class DietForUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int DietTypeId { get; set; }
    }
}
