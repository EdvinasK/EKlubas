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

            entity.Property(e => e.StudyId)
                .HasDefaultValueSql("1");
        }
    }
}
