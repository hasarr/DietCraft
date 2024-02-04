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
        public DbSet<IngredientsForMeal> IngredientsForMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        #endregion

        public IServiceProvider _serviceProvider;
        public DietCraftContext(DbContextOptions<DietCraftContext> options, IServiceProvider serviceProvider)
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
            byte roleId = 0;
            foreach(var role in Enum.GetValues(typeof(RoleNumber)) )
            {
                roleId++;
                modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = roleId,
                        Name = role.ToString()
                    });
            }

                using (var scope = _serviceProvider.CreateScope())
                {
                    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                    
                    modelBuilder.Entity<User>().HasData(
                        new User
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            PasswordHash = userRepository.HashPassword("password_1"),
                            Email = "John@gmail.com",
                            RoleId = (int) RoleNumber.User,
                            UserName = "johndoe1"
                        },
                        new User
                        {
                            Id = 2,
                            FirstName = "Alice",
                            LastName = "Smith",
                            PasswordHash = userRepository.HashPassword("hashed_password_2"),
                            Email = "Alice@gmail.com",
                            RoleId = (int) RoleNumber.Moderator,
                            UserName = "alicesmith12"
                        });


                }
                base.OnModelCreating(modelBuilder);

            
        }

    }
}
