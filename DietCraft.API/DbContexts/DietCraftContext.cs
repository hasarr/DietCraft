using DietCraft.API.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using DietCraft.API.Services;

namespace DietCraft.API.DbContexts
{
    public class DietCraftContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public IServiceProvider _serviceProvider;
        public DietCraftContext(DbContextOptions<DietCraftContext> options, IServiceProvider serviceProvider)
            : base(options) //provide options when context is registered in Program.cs
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            using (var scope = _serviceProvider.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                // Wykonaj operacje na userRepository
                modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                PasswordHash = userRepository.HashPassword("password_1"),
                Email = "John@gmail.com",
                UserName = "johndoe1"
            },
            new User
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Smith",
                PasswordHash = userRepository.HashPassword("hashed_password_2"),
                Role = "User",
                Email = "Alice@gmail.com",
                UserName = "alicesmith12"
            });

            }

            base.OnModelCreating(modelBuilder);

        }
    }
    
}
