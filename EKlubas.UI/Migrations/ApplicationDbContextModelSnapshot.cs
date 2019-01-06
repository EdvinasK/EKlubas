﻿// <auto-generated />
using System;
using EKlubas.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKlubas.UI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EKlubas.Domain.CityNS.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vilnius"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kaunas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Klaipėda"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Šiauliai"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Panevėžys"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Palanga"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Marijampolė"
                        });
                });

            modelBuilder.Entity("EKlubas.Domain.Identities.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("IdentityRoles");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExamAnswer.StudyExamAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StudyExamAnswers");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyTopic.StudyTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyLevel");

                    b.Property<int>("DurationInMinutes");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<string>("Topic");

                    b.HasKey("Id");

                    b.HasIndex("Topic");

                    b.ToTable("StudyTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            Topic = "Math"
                        });
                });

            modelBuilder.Entity("EKlubas.Domain.Users.EKlubasUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthYear");

                    b.Property<int>("CityId");

                    b.Property<int>("Coins")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("LastLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nickname");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("EKlubasUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityRoleClaim<string>s");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserClaim<string>s");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityUserLogin<string>s");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityUserRole<string>s");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("IdentityUserToken<string>s");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExamAnswer.StudyExamAnswer", b =>
                {
                    b.HasOne("EKlubas.Domain.Users.EKlubasUser", "User")
                        .WithMany("StudyExamAnswers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EKlubas.Domain.Users.EKlubasUser", b =>
                {
                    b.HasOne("EKlubas.Domain.CityNS.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.Identities.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.Users.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.Users.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.Identities.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EKlubas.Domain.Users.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.Users.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
