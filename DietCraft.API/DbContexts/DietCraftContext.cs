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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
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
            //TODO: Seeding from ENUM

            modelBuilder.Entity<Role>().HasData(
                new Role{ Id = 1, Name = "User"},
                new Role{ Id = 2, Name = "Moderator"},
                new Role{ Id = 3, Name = "Admin"}
                );

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
