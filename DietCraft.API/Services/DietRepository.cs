using DietCraft.API.Entities;

namespace DietCraft.API.Services
{
    public class DietRepository : IDietRepository
    {
        public Task<bool> DietExistsAsync(int dietId)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Diet>, PaginationMetadata)> GetDietsAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
