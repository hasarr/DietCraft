using DietCraft.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DietCraft.API.Models.Diet
{
    public class DietDto
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int DietTypeId { get; set; }
        public bool IsCustom { get; set; }
        public int UserIdIfCustom { get; set; }
    }
}
