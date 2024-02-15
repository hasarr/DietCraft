using DietCraft.API.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using DietCraft.API.Services;
using Microsoft.Extensions.Options;
using DietCraft.API.Enums;

namespace DietCraft.API.DbContexts
{
    public class DietCraftContext : DbContext
    {
        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Diet> Diets {  get; set; }
        public DbSet<DietType> DietTypes { get; set; }
        public DbSet<UserDiet> UserDiets { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealIngredients> MealIngredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        #endregion

        public IServiceProvider _serviceProvider;
        public DietCraftContext(DbContextOptions<DietCraftContext> options
            , IServiceProvider serviceProvider)
            : base(options) //provide options when context is registered in Program.cs
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Other configuration settings
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

            BulkInsertService.SeedData(modelBuilder, _serviceProvider);
            base.OnModelCreating(modelBuilder);
        }



    }
}
