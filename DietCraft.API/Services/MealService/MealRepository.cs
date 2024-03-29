﻿using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using DietCraft.API.Services.IngredientService;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services.MealService
{
    public class MealRepository : IMealRepository
    {
        private readonly DietCraftContext _context;
        private readonly IIngredientRepository _ingredientRepository;

        public MealRepository(DietCraftContext context, IIngredientRepository ingredientRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this._ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public void AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
        }

        public void AddMealIngredient(MealIngredient mealIngredient)
        {
            _context.MealIngredients.Add(mealIngredient);
        }

        public void DeleteMeal(Meal meal)
        {
            _context.Meals.Remove(meal);
        }

        public void DeleteMealIngredient(MealIngredient mealIngredient)
        {
            _context.MealIngredients.Remove(mealIngredient);
        }

        public async Task<MealIngredient?> GetMealIngredientAsync(int mealId, int ingredientId)
        {
            var mealExists = await MealExistsAsync(mealId);
            var ingredientExists = await _context.Ingredients.AnyAsync(i => i.Id == ingredientId);

            if (!(mealExists || ingredientExists))
                return null;

            var mealIngredient = await _context.MealIngredients.Where(m => m.IngredientId == ingredientId && m.MealId == mealId).FirstOrDefaultAsync();
            return mealIngredient;
        }

        public async Task<(IEnumerable<MealIngredient>, PaginationMetadata)> GetMealIngredientsAsync(int mealId, int pageNumber, int pageSize)
        {
            var mealExists = await MealExistsAsync(mealId);
            var collection = _context.MealIngredients.Where(m => m.MealId == mealId);
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<Meal?> GetMealByIdAsync(int mealId)
        {
            var mealExists = await MealExistsAsync(mealId);
            if (!mealExists)
                return null;

            var meal = await _context.Meals.Where(d => d.Id == mealId).FirstOrDefaultAsync();
            return meal;
        }

        public async Task<(IEnumerable<Meal>, PaginationMetadata)> GetMealsAsync(int pageNumber, int pageSize)
        {
            var collection = _context.Meals as IQueryable<Meal>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<bool> MealIngredientExistsAsync(int mealId, int ingredientId)
        {
            return await _context.MealIngredients.AnyAsync(m => m.MealId == mealId && m.IngredientId == ingredientId);
        }

        public async Task<bool> MealExistsAsync(int mealId)
        {
            return await _context.Meals.AnyAsync(m => m.Id == mealId);
        }

        public (bool,string) VerifyGramMililiters(double grams, double mililiters)
        {
                if (grams > 0 && mililiters > 0)
                    return (false, "Grams and mililiters can't be inserted at the same time (one of them must be equal to 0)");

                if (grams == 0 && mililiters == 0)
                    return (false, "Grams and mililiters weren't filled");

            return (true,"");
        }
    }
}
