using EKlubas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Persistence.Configurations
{
    public class StudyExamsConfiguration : IEntityTypeConfiguration<StudyExam>
    {
        public void Configure(EntityTypeBuilder<StudyExam> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.UserId);

            entity.HasOne(se => se.User)
                .WithMany(u => u.StudyExams)
                .HasForeignKey(u => u.UserId);

            entity.Property(e => e.PassMark)
                .HasDefaultValueSql("50");

            entity.Property(e => e.Reward)
                .HasDefaultValueSql("10");

            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");
        }
    }
}
