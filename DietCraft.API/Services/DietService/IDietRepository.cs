using DietCraft.API.Entities;

namespace DietCraft.API.Services.DietService
{
    public interface IDietRepository
    {
        public Task<(IEnumerable<Diet>, PaginationMetadata)> GetDietsAsync(int pageNumber, int pageSize);
        public Task<Diet?> GetDietByIdAsync(int dietId);
        public Task<bool> DietExistsAsync(int dietId);
        public void AddDiet(Diet diet);
        public void DeleteDiet(Diet diet);

        public Task<(IEnumerable<DietType>, PaginationMetadata)> GetDietTypesAsync(int pageNumber, int pageSize);
        public Task<DietType?> GetDietTypeByIdAsync(int id);
        public Task<bool> DietTypeExistsAsync(int dietTypeId);
        public void AddDietType(DietType dietType);
        public void DeleteDietType(DietType dietType);

    }
}
