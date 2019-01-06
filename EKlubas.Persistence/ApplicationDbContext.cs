﻿using System;
using System.Collections.Generic;
using System.Text;
using EKlubas.Contracts.Abstractions;
using EKlubas.Domain.CityNS;
using EKlubas.Domain.StudyExamAnswer;
using EKlubas.Domain.StudyTopic;
using EKlubas.Domain.Users;
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

            modelBuilder.Entity<City>().HasData(CitySeed.GetCityListSeed());
            modelBuilder.Entity<StudyTopic>().HasData(StudyTopicSeed.GetStudyTopicListSeed());
        }
    }
}
