using DietCraft.API.Entities;

namespace DietCraft.API.Services.IngredientService
{
    public interface IIngredientRepository
    {
        public Task<(IEnumerable<Ingredient>, PaginationMetadata)> GetIngredientsAsync(int pageNumber, int pageSize);
        public Task<Ingredient?> GetIngredientByIdAsync(int ingredientId);
        public Task<bool> IngredientExistsAsync(int ingredientId);
        public Task<bool> IngredientNameExistsAsync(string ingredientName);
        public void AddIngredient(Ingredient ingredient);
        public void DeleteIngredient(Ingredient ingredient);
    }
}
