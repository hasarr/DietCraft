using DietCraft.API.Entities;

namespace DietCraft.API.Services
{
    public interface IDietRepository
    {
        public Task<(IEnumerable<Diet>, PaginationMetadata)>  GetDietsAsync(int pageNumber, int pageSize);
        public Task<bool> DietExistsAsync(int dietId);
    }
}
