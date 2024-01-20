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
    [Migration("20240119152152_RoleEnums")]
    partial class RoleEnums
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("DietCraft.API.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
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
                            PasswordHash = "$2a$10$ZDTpdDbqjGG4aQ1T0PPYa.eOg0XBcYAkNaedmla5CEkQ4qt2sneEW",
                            RoleId = (byte)1,
                            UserName = "johndoe1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Alice@gmail.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            PasswordHash = "$2a$10$ES05Ef1XjeULTRX7Iqd6UeyDUwliklehIlodZrZBhayH./Ke4pTEO",
                            RoleId = (byte)2,
                            UserName = "alicesmith12"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
