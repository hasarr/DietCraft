namespace DietCraft.API.Models.Diet
{
    public class DietForCreationDto
    {
        public string? Name { get; set; }
        public int DietTypeId { get; set; }
        public bool isCustom { get; set; }
        public int UserIdIfCustom { get; set; }
    }
}
