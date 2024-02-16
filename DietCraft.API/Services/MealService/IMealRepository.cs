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
    }
}
