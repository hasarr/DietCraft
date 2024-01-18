﻿// <auto-generated />
using DietCraft.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DietCraft.API.Migrations
{
    [DbContext(typeof(DietCraftContext))]
    partial class DietCraftContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("DietCraft.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "John@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PasswordHash = "$2a$10$gEd.cTI1iDjDSPEhpo1Qb.zs/kYs4pqMa/Sr7C9kGuk1OahSfga/O",
                            Role = "User",
                            UserName = "johndoe1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Alice@gmail.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            PasswordHash = "$2a$10$e2fbIxkVIzN6FWaVT7T1hepwOUuSFkj29ustBQGRM4AvaI/z73ORS",
                            Role = "User",
                            UserName = "alicesmith12"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
