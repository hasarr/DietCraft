using DietCraft.API.Entities;
using DietCraft.API.Models.Diet;

namespace DietCraft.API.Services.DietService
{
    public interface IDietRepository
    {
        public Task<(IEnumerable<Diet>, PaginationMetadata)> GetDietsAsync(int pageNumber, int pageSize);
        public Task<Diet?> GetDietByIdAsync(int dietId);
        public Task<(List<UserDiet?>, PaginationMetadata)> GetDietsForUserAsync(string userName, int pageNumber, int pageSize);
        public Task<UserDiet?> GetDietForUserAsync(string userName, int dietId);
        public Task<bool> DietExistsAsync(int dietId);
        public void AddDiet(Diet diet);
        public void DeleteDiet(Diet diet);
        public void DeleteDietForUser(UserDiet userDiet);
        public Task ClearDietsForUserAsync(string userName);
        public void AddUserDiet(UserDiet diet);

        public Task<(IEnumerable<DietType>, PaginationMetadata)> GetDietTypesAsync(int pageNumber, int pageSize);
        public Task<DietType?> GetDietTypeByIdAsync(int id);
        public Task<bool> DietTypeExistsAsync(int dietTypeId);
        public void AddDietType(DietType dietType);
        public void DeleteDietType(DietType dietType);

    }
}
