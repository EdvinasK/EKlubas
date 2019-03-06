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
    public class StudyTopicConfiguration : IEntityTypeConfiguration<StudyTopic>
    {
        public void Configure(EntityTypeBuilder<StudyTopic> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.Topic);

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.Topic)
                .IsRequired();

            entity.Property(e => e.TaskName)
                .HasDefaultValue("-")
                .IsRequired();

            entity.Property(e => e.IsExamPrepared)
                .HasDefaultValue("false");

            entity.Property(e => e.IsExamOnly)
                .HasDefaultValue("false");

            entity.Property(e => e.IsNew)
                .HasDefaultValue("true");

            entity.Property(e => e.CreatedTimestamp)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

            entity.Property(e => e.PassMark)
                .HasDefaultValue(50)
                .IsRequired();

            entity.Property(e => e.Reward)
                .HasDefaultValue(7)
                .IsRequired();

            entity.Property(e => e.ImgUrlPath)
                .HasMaxLength(128)
                .HasDefaultValue("/images/EquationHouse.png");

            entity.Property(e => e.StudyId)
                .HasDefaultValueSql("1");
        }
    }
}
