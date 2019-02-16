using System;
using System.Collections.Generic;
using System.Text;
using EKlubas.Contracts.Persistence;
using EKlubas.Domain;
using EKlubas.Persistence.Configurations;
using EKlubas.Persistence.DatabaseSeed;
using EKlubas.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EKlubas.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<EKlubasUser, Domain.Identities.IdentityRole, string>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<City> Cities { get; set; }
        public DbSet<StudyTopic> StudyTopics { get; set; }
        public DbSet<StudyExamAnswer> StudyExamAnswers { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyExam> StudyExams { get; set; }
        public DbSet<RewardHistory> RewardHistories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=eklubas_db;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModeBuilderExtensions.PluralizingTableNameConvention(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new EKlubasUserConfiguration());
            modelBuilder.ApplyConfiguration(new StudyTopicConfiguration());
            modelBuilder.ApplyConfiguration(new StudyExamAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new StudyConfiguration());
            modelBuilder.ApplyConfiguration(new StudyExamsConfiguration());

            modelBuilder.Entity<City>().HasData(CitySeed.GetCityListSeed());
            modelBuilder.Entity<StudyTopic>().HasData(StudyTopicSeed.GetStudyTopicListSeed());
            modelBuilder.Entity<Study>().HasData(StudySeed.GetStudyListSeed());
        }
    }
}
