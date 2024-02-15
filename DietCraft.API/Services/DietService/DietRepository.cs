using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services.DietService
{
    public class DietRepository : IDietRepository
    {
        private readonly DietCraftContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DietRepository(DietCraftContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<(IEnumerable<Diet>, PaginationMetadata)> GetDietsAsync(int pageNumber, int pageSize)
        {
            var collection = _context.Diets as IQueryable<Diet>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);

        }

        public async Task<Diet> GetDietByIdAsync(int dietId)
        {
            var dietExists = await DietExistsAsync(dietId);
            if (!dietExists)
                return null;

            var diet = await _context.Diets.Where(d => d.Id == dietId).FirstOrDefaultAsync();
            return diet;
        }

        public async Task<bool> DietExistsAsync(int dietId)
        {
            return await _context.Diets.AnyAsync(d => d.Id == dietId);
        }

        public async Task<bool> DietTypeExistsAsync(int dietTypeId)
        {
            return await _context.DietTypes.AnyAsync(d => d.Id == dietTypeId);
        }

        public void AddDiet(Diet diet)
        {
            _context.Diets.Add(diet);
        }

        public void DeleteDiet(Diet diet)
        {
            _context.Diets.Remove(diet);
        }

        
        public async Task<(IEnumerable<DietType>, PaginationMetadata)> GetDietTypesAsync(int pageNumber, int pageSize)
        {
            var collection = _context.DietTypes as IQueryable<DietType>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);

        }

    }
}
