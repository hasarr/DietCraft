namespace DietCraft.API.Models.Diet
{
    public class UserDietWithDetailsDto
    {
        public int DietId { get; set; }
        public string? Name { get; set; }
        public int DietTypeId { get; set; }
        public bool IsCustom { get; set; }
        public int UserIdIfCustom { get; set; }
        public int MaxKcal {  get; set; }
    }
}
