﻿// <auto-generated />
using DietCraft.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DietCraft.API.Migrations
{
    [DbContext(typeof(DietCraftContext))]
    [Migration("20240221192131_indexMealIngredient2")]
    partial class indexMealIngredient2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("DietCraft.API.Entities.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DietTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserIdIfCustom")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DietTypeId");

                    b.HasIndex("Name", "IsCustom", "UserIdIfCustom")
                        .IsUnique();

                    b.ToTable("Diets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DietTypeId = 1,
                            IsCustom = false,
                            Name = "Dieta wegańska",
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 2,
                            DietTypeId = 2,
                            IsCustom = false,
                            Name = "Dieta keto",
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 3,
                            DietTypeId = 3,
                            IsCustom = true,
                            Name = "Dieta zbalansowana",
                            UserIdIfCustom = 1
                        },
                        new
                        {
                            Id = 4,
                            DietTypeId = 4,
                            IsCustom = true,
                            Name = "Dieta niskowęglowodanowa",
                            UserIdIfCustom = 2
                        },
                        new
                        {
                            Id = 5,
                            DietTypeId = 5,
                            IsCustom = true,
                            Name = "Dieta białkowa",
                            UserIdIfCustom = 3
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.DietType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("CarbPercent")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("FatPercent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("ProteinPercent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserIdIfCustom")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name", "IsCustom", "UserIdIfCustom")
                        .IsUnique();

                    b.ToTable("DietTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarbPercent = (byte)50,
                            FatPercent = (byte)25,
                            IsCustom = false,
                            Name = "Wege",
                            ProteinPercent = (byte)25,
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 2,
                            CarbPercent = (byte)10,
                            FatPercent = (byte)60,
                            IsCustom = false,
                            Name = "Keto",
                            ProteinPercent = (byte)30,
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 3,
                            CarbPercent = (byte)40,
                            FatPercent = (byte)30,
                            IsCustom = false,
                            Name = "Balans",
                            ProteinPercent = (byte)30,
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 4,
                            CarbPercent = (byte)20,
                            FatPercent = (byte)40,
                            IsCustom = false,
                            Name = "Niskowęglowodanowa",
                            ProteinPercent = (byte)40,
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 5,
                            CarbPercent = (byte)45,
                            FatPercent = (byte)35,
                            IsCustom = false,
                            Name = "Białkowa",
                            ProteinPercent = (byte)20,
                            UserIdIfCustom = 0
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarbGram")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FatGram")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kcal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProteinGram")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarbGram = 1,
                            FatGram = 11,
                            IsVegan = true,
                            Kcal = 155,
                            Name = "Jajka",
                            Price = 1.0,
                            ProteinGram = 13
                        },
                        new
                        {
                            Id = 2,
                            CarbGram = 3,
                            FatGram = 0,
                            IsVegan = false,
                            Kcal = 23,
                            Name = "Szpinak",
                            Price = 2.0,
                            ProteinGram = 2
                        },
                        new
                        {
                            Id = 3,
                            CarbGram = 4,
                            FatGram = 0,
                            IsVegan = true,
                            Kcal = 18,
                            Name = "Pomidory",
                            Price = 3.0,
                            ProteinGram = 1
                        },
                        new
                        {
                            Id = 4,
                            CarbGram = 0,
                            FatGram = 14,
                            IsVegan = false,
                            Kcal = 239,
                            Name = "Kurczak",
                            Price = 4.0,
                            ProteinGram = 27
                        },
                        new
                        {
                            Id = 5,
                            CarbGram = 0,
                            FatGram = 100,
                            IsVegan = true,
                            Kcal = 884,
                            Name = "Oliwa z oliwek",
                            Price = 5.0,
                            ProteinGram = 0
                        },
                        new
                        {
                            Id = 6,
                            CarbGram = 7,
                            FatGram = 0,
                            IsVegan = false,
                            Kcal = 34,
                            Name = "Brokuły",
                            Price = 6.0,
                            ProteinGram = 3
                        },
                        new
                        {
                            Id = 7,
                            CarbGram = 10,
                            FatGram = 0,
                            IsVegan = true,
                            Kcal = 40,
                            Name = "Cebula",
                            Price = 7.0,
                            ProteinGram = 1
                        },
                        new
                        {
                            Id = 8,
                            CarbGram = 28,
                            FatGram = 0,
                            IsVegan = false,
                            Kcal = 130,
                            Name = "Ryż",
                            Price = 8.0,
                            ProteinGram = 2
                        },
                        new
                        {
                            Id = 9,
                            CarbGram = 10,
                            FatGram = 0,
                            IsVegan = true,
                            Kcal = 41,
                            Name = "Marchewka",
                            Price = 9.0,
                            ProteinGram = 1
                        },
                        new
                        {
                            Id = 10,
                            CarbGram = 0,
                            FatGram = 8,
                            IsVegan = false,
                            Kcal = 184,
                            Name = "Tuńczyk",
                            Price = 10.0,
                            ProteinGram = 25
                        },
                        new
                        {
                            Id = 11,
                            CarbGram = 3,
                            FatGram = 0,
                            IsVegan = true,
                            Kcal = 15,
                            Name = "Ogórki",
                            Price = 11.0,
                            ProteinGram = 1
                        },
                        new
                        {
                            Id = 12,
                            CarbGram = 1,
                            FatGram = 32,
                            IsVegan = false,
                            Kcal = 403,
                            Name = "Ser",
                            Price = 12.0,
                            ProteinGram = 25
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserIdIfCustom")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name", "IsCustom", "UserIdIfCustom")
                        .IsUnique();

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCustom = false,
                            IsVegan = false,
                            Name = "Jajecznica",
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 2,
                            IsCustom = false,
                            IsVegan = true,
                            Name = "Sałatka grecka",
                            UserIdIfCustom = 0
                        },
                        new
                        {
                            Id = 3,
                            IsCustom = true,
                            IsVegan = false,
                            Name = "Kurczak z ryżem",
                            UserIdIfCustom = 2
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.MealIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Grams")
                        .HasColumnType("TEXT");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MealId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Mililiters")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("IngredientId", "MealId")
                        .IsUnique();

                    b.ToTable("MealIngredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Grams = 100m,
                            IngredientId = 1,
                            IsOptional = false,
                            MealId = 1,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Grams = 150m,
                            IngredientId = 2,
                            IsOptional = true,
                            MealId = 1,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            Grams = 50m,
                            IngredientId = 3,
                            IsOptional = true,
                            MealId = 1,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            Grams = 80m,
                            IngredientId = 4,
                            IsOptional = true,
                            MealId = 1,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            Grams = 100m,
                            IngredientId = 3,
                            IsOptional = false,
                            MealId = 2,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Grams = 80m,
                            IngredientId = 5,
                            IsOptional = false,
                            MealId = 2,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 7,
                            Grams = 120m,
                            IngredientId = 6,
                            IsOptional = false,
                            MealId = 2,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 8,
                            Grams = 150m,
                            IngredientId = 4,
                            IsOptional = false,
                            MealId = 3,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 9,
                            Grams = 100m,
                            IngredientId = 8,
                            IsOptional = false,
                            MealId = 3,
                            Mililiters = 0m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 10,
                            Grams = 80m,
                            IngredientId = 9,
                            IsOptional = true,
                            MealId = 3,
                            Mililiters = 0m,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescriptionHTML")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsStepByStep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MealId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TitleHTML")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DescriptionHTML = "<p>Delicious broccoli salad recipe.</p>",
                            IsStepByStep = true,
                            MealId = 1,
                            Name = "Przepis 1",
                            TitleHTML = "<h1>Broccoli Salad</h1>"
                        },
                        new
                        {
                            Id = 2,
                            DescriptionHTML = "<p>Perfectly grilled chicken recipe.</p>",
                            IsStepByStep = true,
                            MealId = 2,
                            Name = "Przepis 2",
                            TitleHTML = "<h1>Grilled Chicken</h1>"
                        },
                        new
                        {
                            Id = 3,
                            DescriptionHTML = "<p>Simple and tasty salmon fillet recipe.</p>",
                            IsStepByStep = true,
                            MealId = 3,
                            Name = "Przepis 3",
                            TitleHTML = "<h1>Salmon Fillet</h1>"
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.Role", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "User"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = (byte)4,
                            Name = "Viewer"
                        },
                        new
                        {
                            Id = (byte)5,
                            Name = "Tester"
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Name", "UserId")
                        .IsUnique();

                    b.ToTable("ShoppingLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lista zakupów 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lista zakupów 2",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lista zakupów 3",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lista zakupów 4",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lista zakupów 5",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.ShoppingListIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ShoppingListId", "IngredientId")
                        .IsUnique();

                    b.ToTable("ShoppingListIngredient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IngredientId = 1,
                            Quantity = 2,
                            ShoppingListId = 1
                        },
                        new
                        {
                            Id = 2,
                            IngredientId = 2,
                            Quantity = 1,
                            ShoppingListId = 1
                        },
                        new
                        {
                            Id = 3,
                            IngredientId = 3,
                            Quantity = 3,
                            ShoppingListId = 2
                        },
                        new
                        {
                            Id = 4,
                            IngredientId = 4,
                            Quantity = 2,
                            ShoppingListId = 3
                        },
                        new
                        {
                            Id = 5,
                            IngredientId = 5,
                            Quantity = 1,
                            ShoppingListId = 4
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PasswordHash = "$2a$10$vhOzWKOnIpwK7mpdGT9YoefPhjLXlWOhKek515SivvdPrmyRur7pG",
                            RoleId = (byte)1,
                            UserName = "john_doe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            PasswordHash = "$2a$10$fqEAOFe99iKmpOPl5H0aEef8Xik6er43lPCsEUBjRoey2kEkniCx6",
                            RoleId = (byte)2,
                            UserName = "alice_smith"
                        },
                        new
                        {
                            Id = 3,
                            Email = "bob@example.com",
                            FirstName = "Bob",
                            LastName = "Johnson",
                            PasswordHash = "$2a$10$HPiOC/I8bxURtBVYyd3r6.vM4e9KrX4jPT3nUV6GS64tSHdOhWZoG",
                            RoleId = (byte)3,
                            UserName = "bob_johnson"
                        },
                        new
                        {
                            Id = 4,
                            Email = "emily@example.com",
                            FirstName = "Emily",
                            LastName = "Brown",
                            PasswordHash = "$2a$10$i.kxcHERFqaIqNJT7/HYOu8r8Qnx0FNg/ax0OOEgsw5s/cyJ2HU2e",
                            RoleId = (byte)4,
                            UserName = "emily_brown"
                        },
                        new
                        {
                            Id = 5,
                            Email = "david@example.com",
                            FirstName = "David",
                            LastName = "Wilson",
                            PasswordHash = "$2a$10$YPMts6V0oiFu5kxynu.3yeDkW3bhZKzyszBEDC/LYZTrzqHKFEr.q",
                            RoleId = (byte)5,
                            UserName = "david_wilson"
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.UserDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DietId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxKcal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("DietId", "UserId")
                        .IsUnique();

                    b.ToTable("UserDiets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DietId = 1,
                            MaxKcal = 2000,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DietId = 2,
                            MaxKcal = 1800,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            DietId = 3,
                            MaxKcal = 2200,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            DietId = 4,
                            MaxKcal = 1900,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            DietId = 5,
                            MaxKcal = 2100,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("DietCraft.API.Entities.Diet", b =>
                {
                    b.HasOne("DietCraft.API.Entities.DietType", "DietType")
                        .WithMany()
                        .HasForeignKey("DietTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DietType");
                });

            modelBuilder.Entity("DietCraft.API.Entities.MealIngredient", b =>
                {
                    b.HasOne("DietCraft.API.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietCraft.API.Entities.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("DietCraft.API.Entities.Recipe", b =>
                {
                    b.HasOne("DietCraft.API.Entities.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("DietCraft.API.Entities.ShoppingList", b =>
                {
                    b.HasOne("DietCraft.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietCraft.API.Entities.ShoppingListIngredient", b =>
                {
                    b.HasOne("DietCraft.API.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietCraft.API.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListIngredients")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("DietCraft.API.Entities.User", b =>
                {
                    b.HasOne("DietCraft.API.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DietCraft.API.Entities.UserDiet", b =>
                {
                    b.HasOne("DietCraft.API.Entities.Diet", "Diet")
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietCraft.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietCraft.API.Entities.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
