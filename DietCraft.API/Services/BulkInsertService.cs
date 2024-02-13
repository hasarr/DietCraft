﻿using System;
using System.Collections.Generic;
using DietCraft.API.Entities;
using DietCraft.API.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services
{
    public class BulkInsertService
    {

        public static void SeedData(ModelBuilder modelBuilder, IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var _userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            // Wstawianie danych dla DietType
            modelBuilder.Entity<DietType>().HasData(
                new DietType { Id = 1, Name = "Wege", CarbPercent = 50, ProteinPercent = 25, FatPercent = 25 },
                new DietType { Id = 2, Name = "Keto", CarbPercent = 10, ProteinPercent = 30, FatPercent = 60 },
                new DietType { Id = 3, Name = "Balans", CarbPercent = 40, ProteinPercent = 30, FatPercent = 30 },
                new DietType { Id = 4, Name = "Niskowęglowodanowa", CarbPercent = 20, ProteinPercent = 40, FatPercent = 40 },
                new DietType { Id = 5, Name = "Białkowa", CarbPercent = 45, ProteinPercent = 20, FatPercent = 35 }
            );

            // Wstawianie danych dla Ingredient
            modelBuilder.Entity<Ingredient>().HasData(
                // Dodaj 12 różnych składników
                new Ingredient { Id = 1, Name = "Jajka", Price = 1.0m, IsVegan = true },
                new Ingredient { Id = 2, Name = "Szpinak", Price = 2.0m, IsVegan = false },
                new Ingredient { Id = 3, Name = "Pomidory", Price = 3.0m, IsVegan = true },
                new Ingredient { Id = 4, Name = "Kurczak", Price = 4.0m, IsVegan = false },
                new Ingredient { Id = 5, Name = "Oliwa z oliwek", Price = 5.0m, IsVegan = true },
                new Ingredient { Id = 6, Name = "Brokuły", Price = 6.0m, IsVegan = false },
                new Ingredient { Id = 7, Name = "Cebula", Price = 7.0m, IsVegan = true },
                new Ingredient { Id = 8, Name = "Ryż", Price = 8.0m, IsVegan = false },
                new Ingredient { Id = 9, Name = "Marchewka", Price = 9.0m, IsVegan = true },
                new Ingredient { Id = 10, Name = "Tuńczyk", Price = 10.0m, IsVegan = false },
                new Ingredient { Id = 11, Name = "Ogórki", Price = 11.0m, IsVegan = true },
                new Ingredient { Id = 12, Name = "Ser", Price = 12.0m, IsVegan = false }
            );

            // Wstawianie danych dla Meal
            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, Name = "Jajecznica", IsVegan = false, isCustom = false },
                new Meal { Id = 2, Name = "Sałatka grecka", IsVegan = true, isCustom = false },
                new Meal { Id = 3, Name = "Kurczak z ryżem", IsVegan = false, isCustom = true, UserIdIfCustom = 2 }
            );

            // Wstawianie danych dla IngredientsForMeal
            modelBuilder.Entity<IngredientsForMeal>().HasData(
                // Dodaj składniki dla każdego posiłku
                new IngredientsForMeal { Id = 1, MealId = 1, IngredientId = 1, IsOptional = false, Grams = 100, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 2, MealId = 1, IngredientId = 2, IsOptional = true, Grams = 150, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 3, MealId = 1, IngredientId = 3, IsOptional = true, Grams = 50, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 4, MealId = 1, IngredientId = 4, IsOptional = true, Grams = 80, Mililiters = 0, Quantity = 1 },

                new IngredientsForMeal { Id = 5, MealId = 2, IngredientId = 3, IsOptional = false, Grams = 100, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 6, MealId = 2, IngredientId = 5, IsOptional = false, Grams = 80, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 7, MealId = 2, IngredientId = 6, IsOptional = false, Grams = 120, Mililiters = 0, Quantity = 1 },

                new IngredientsForMeal { Id = 8, MealId = 3, IngredientId = 4, IsOptional = false, Grams = 150, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 9, MealId = 3, IngredientId = 8, IsOptional = false, Grams = 100, Mililiters = 0, Quantity = 1 },
                new IngredientsForMeal { Id = 10, MealId = 3, IngredientId = 9, IsOptional = true, Grams = 80, Mililiters = 0, Quantity = 1 }
            );


            // Wstawianie danych dla ShoppingList
            modelBuilder.Entity<ShoppingList>().HasData(
                new ShoppingList { Id = 1, Name = "Lista zakupów 1", UserId = 1 },
                new ShoppingList { Id = 2, Name = "Lista zakupów 2", UserId = 2 },
                new ShoppingList { Id = 3, Name = "Lista zakupów 3", UserId = 3 },
                new ShoppingList { Id = 4, Name = "Lista zakupów 4", UserId = 4 },
                new ShoppingList { Id = 5, Name = "Lista zakupów 5", UserId = 5 }
                // Dodaj więcej list zakupów tutaj...
            );

            // Wstawianie danych dla ShoppingListIngredients
            modelBuilder.Entity<ShoppingListIngredients>().HasData(
                new ShoppingListIngredients { Id = 1, ShoppingListId = 1, IngredientId = 1, Quantity = 2 },
                new ShoppingListIngredients { Id = 2, ShoppingListId = 1, IngredientId = 2, Quantity = 1 },
                new ShoppingListIngredients { Id = 3, ShoppingListId = 2, IngredientId = 3, Quantity = 3 },
                new ShoppingListIngredients { Id = 4, ShoppingListId = 3, IngredientId = 4, Quantity = 2 },
                new ShoppingListIngredients { Id = 5, ShoppingListId = 4, IngredientId = 5, Quantity = 1 }
            );

            // Wstawianie danych dla innych encji, jeśli wymagane
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Manager" },
                new Role { Id = 4, Name = "Viewer" },
                new Role { Id = 5, Name = "Tester" }
            );

            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", UserName = "john_doe", PasswordHash = _userRepository.HashPassword("123"), RoleId = 1 },
            new User { Id = 2, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", UserName = "alice_smith", PasswordHash = _userRepository.HashPassword("123"), RoleId = 2 },
            new User { Id = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com", UserName = "bob_johnson", PasswordHash = _userRepository.HashPassword("123"), RoleId = 3 },
            new User { Id = 4, FirstName = "Emily", LastName = "Brown", Email = "emily@example.com", UserName = "emily_brown", PasswordHash = _userRepository.HashPassword("123"), RoleId = 4 },
            new User { Id = 5, FirstName = "David", LastName = "Wilson", Email = "david@example.com", UserName = "david_wilson", PasswordHash = _userRepository.HashPassword("123"), RoleId = 5 }
            );

            modelBuilder.Entity<Diet>().HasData(
                new Diet { Id = 1, Name = "Dieta wegańska", DietTypeId = 1, isCustom = false, UserIdIfCustom = 0 },
                new Diet { Id = 2, Name = "Dieta keto", DietTypeId = 2, isCustom = false, UserIdIfCustom = 0 },
                new Diet { Id = 3, Name = "Dieta zbalansowana", DietTypeId = 3, isCustom = true, UserIdIfCustom = 1 },
                new Diet { Id = 4, Name = "Dieta niskowęglowodanowa", DietTypeId = 4, isCustom = true, UserIdIfCustom = 2 },
                new Diet { Id = 5, Name = "Dieta białkowa", DietTypeId = 5, isCustom = true, UserIdIfCustom = 3 }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, Name = "Przepis 1", DescriptionHTML = "<p>Delicious broccoli salad recipe.</p>", TitleHTML = "<h1>Broccoli Salad</h1>", MealId = 1, isStepByStep = true },
                new Recipe { Id = 2, Name = "Przepis 2", DescriptionHTML = "<p>Perfectly grilled chicken recipe.</p>", TitleHTML = "<h1>Grilled Chicken</h1>", MealId = 2, isStepByStep = true },
                new Recipe { Id = 3, Name = "Przepis 3", DescriptionHTML = "<p>Simple and tasty salmon fillet recipe.</p>", TitleHTML = "<h1>Salmon Fillet</h1>", MealId = 3, isStepByStep = true }
            );

            modelBuilder.Entity<UserDiet>().HasData(
                new UserDiet { Id = 1, DietId = 1, UserId = 1, MaxKcal = 2000 },
                new UserDiet { Id = 2, DietId = 2, UserId = 2, MaxKcal = 1800 },
                new UserDiet { Id = 3, DietId = 3, UserId = 3, MaxKcal = 2200 },
                new UserDiet { Id = 4, DietId = 4, UserId = 4, MaxKcal = 1900 },
                new UserDiet { Id = 5, DietId = 5, UserId = 5, MaxKcal = 2100 }
            );
        }
    }
}
