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
    public class StudyExamAnswerConfiguration : IEntityTypeConfiguration<StudyExamAnswer>
    {
        public void Configure(EntityTypeBuilder<StudyExamAnswer> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasIndex(e => e.StudyExamId);

            entity.HasOne(sea => sea.StudyExam)
                .WithMany(se => se.StudyExamResults)
                .HasForeignKey(sea => sea.StudyExamId);
        }
    }
}
