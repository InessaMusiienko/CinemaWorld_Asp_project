﻿// <auto-generated />
using System;
using CinemaWorld.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaWorld.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230615134429_CustomTablesAdded")]
    partial class CustomTablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaWorld.Data.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Rating")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "United States",
                            Description = "Nearly 5,000 years after he was bestowed with the almighty powers of the Egyptian gods--and imprisoned just as quickly--Black Adam is freed from his earthly tomb, ready to unleash his unique form of justice on the modern world.",
                            Director = "Jaume Collet-Serra",
                            GenreId = 5,
                            ImageUrl = "data:image/jpeg;base64,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",
                            Name = "Black Adam",
                            Rating = 6m,
                            VideoUrl = "https://www.youtube.com/watch?v=X0tOpBuYasI",
                            Year = "2021"
                        });
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Children"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.IdentityUserFilm", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FilmId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserFilms");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.Film", b =>
                {
                    b.HasOne("CinemaWorld.Data.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.IdentityUserFilm", b =>
                {
                    b.HasOne("CinemaWorld.Data.Models.Film", "Film")
                        .WithMany("UsersFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.Film", b =>
                {
                    b.Navigation("UsersFilms");
                });

            modelBuilder.Entity("CinemaWorld.Data.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
