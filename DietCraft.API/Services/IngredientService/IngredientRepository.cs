using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services.IngredientService
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DietCraftContext _context;

        public IngredientRepository(DietCraftContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region IngredientEndPoints
        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int ingredientId)
        {
            var ingredientExists = await IngredientExistsAsync(ingredientId);
            if (!ingredientExists)
                return null;

            var ingredient = await _context.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefaultAsync();
            return ingredient;
        }

        public async Task<(IEnumerable<Ingredient>, PaginationMetadata)> GetIngredientsAsync(int pageNumber, int pageSize)
        {
            var collection = _context.Ingredients as IQueryable<Ingredient>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<bool> IngredientExistsAsync(int ingredientId)
        {
            return await _context.Ingredients.AnyAsync(i => i.Id == ingredientId);
        }

        public async Task<bool> IngredientNameExistsAsync(string ingredientName)
        {
            return await _context.Ingredients.AnyAsync(i => i.Name.ToLower() == ingredientName.ToLower());
        }
        #endregion
    }
}
