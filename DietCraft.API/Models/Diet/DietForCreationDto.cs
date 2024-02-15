namespace DietCraft.API.Models.Diet
{
    public class DietForCreationDto
    {
        public string? Name { get; set; }
        public int DietTypeId { get; set; }
        public bool IsCustom { get; set; }
        public int UserIdIfCustom { get; set; }
    }
}
