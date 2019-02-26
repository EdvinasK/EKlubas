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
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EKlubas.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

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

            modelBuilder.Entity("EKlubas.Domain.EKlubasUser", b =>
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

            modelBuilder.Entity("EKlubas.Domain.RewardHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReceiveTime");

                    b.Property<int>("Reward");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RewardHistories");
                });

            modelBuilder.Entity("EKlubas.Domain.Study", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Studies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "-Nepriskirta-"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Matematika"
                        });
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<bool>("IsNew");

                    b.Property<int>("PassMark")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("50");

                    b.Property<int>("Reward")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("10");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StudyExams");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExamAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<Guid>("StudyExamId");

                    b.HasKey("Id");

                    b.HasIndex("StudyExamId");

                    b.ToTable("StudyExamAnswers");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyLevel");

                    b.Property<int>("DurationInMinutes");

                    b.Property<string>("ExamDescription");

                    b.Property<string>("ImgUrlPath")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasDefaultValue("/images/EquationHouse.png");

                    b.Property<bool>("IsExamOnly")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsExamPrepared")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsNew")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Link");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PassMark")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(50);

                    b.Property<int>("Reward")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(7);

                    b.Property<int>("StudyId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StudyId");

                    b.HasIndex("Topic");

                    b.ToTable("StudyTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = true,
                            IsNew = true,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 3,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "Equality",
                            Name = "Lygu, daugiau arba mažiau",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 4,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 5,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 6,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "Equation",
                            Name = "Lygtys su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 7,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 1,
                            DurationInMinutes = 5,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 8,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 2,
                            DurationInMinutes = 10,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        },
                        new
                        {
                            Id = 9,
                            CreatedTimestamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                            DifficultyLevel = 3,
                            DurationInMinutes = 15,
                            ExamDescription = "Lengvas testas sudarytas iš mažų temos uždavinių",
                            IsExamOnly = false,
                            IsExamPrepared = false,
                            IsNew = true,
                            Link = "EqualityWithVariable",
                            Name = "Lygybės su vienu kintamuoju",
                            PassMark = 50,
                            Reward = 7,
                            StudyId = 0,
                            Topic = "Math"
                        });
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

            modelBuilder.Entity("EKlubas.Domain.EKlubasUser", b =>
                {
                    b.HasOne("EKlubas.Domain.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EKlubas.Domain.RewardHistory", b =>
                {
                    b.HasOne("EKlubas.Domain.EKlubasUser", "User")
                        .WithMany("RewardHistories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExam", b =>
                {
                    b.HasOne("EKlubas.Domain.EKlubasUser", "User")
                        .WithMany("StudyExams")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EKlubas.Domain.StudyExamAnswer", b =>
                {
                    b.HasOne("EKlubas.Domain.StudyExam", "StudyExam")
                        .WithMany("StudyExamResults")
                        .HasForeignKey("StudyExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EKlubas.Domain.StudyTopic", b =>
                {
                    b.HasOne("EKlubas.Domain.Study", "Study")
                        .WithMany("StudyTopics")
                        .HasForeignKey("StudyId")
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
                    b.HasOne("EKlubas.Domain.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.EKlubasUser")
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

                    b.HasOne("EKlubas.Domain.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EKlubas.Domain.EKlubasUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
