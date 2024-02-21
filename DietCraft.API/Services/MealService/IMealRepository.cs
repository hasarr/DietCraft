using DietCraft.API.Entities;

namespace DietCraft.API.Services.MealService
{
    public interface IMealRepository
    {
        public Task<(IEnumerable<Meal>, PaginationMetadata)> GetMealsAsync(int pageNumber, int pageSize);
        public Task<Meal?> GetMealByIdAsync(int mealId);
        public Task<bool> MealExistsAsync(int mealId);
        public void AddMeal(Meal meal);
        public void DeleteMeal(Meal meal);

        public Task<(IEnumerable<MealIngredient>, PaginationMetadata)> GetIngredientsForMealAsync(int mealId, int pageNumber, int pageSize);
        public Task<MealIngredient?> GetIngredientForMealAsync(int mealId, int ingredientId);
        public Task<bool> IngredientForMealExistsAsync(int mealId, int ingredientId);
        public void AddMealIngredient(MealIngredient mealIngredient);
        public void DeleteMealIngredient(MealIngredient mealIngredient);
    }
}
