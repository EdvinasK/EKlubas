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
    public class EKlubasUserConfiguration : IEntityTypeConfiguration<EKlubasUser>
    {
        public void Configure(EntityTypeBuilder<EKlubasUser> entity)
        {
            entity.Property(e => e.Coins)
                .HasDefaultValue(0);

            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasDefaultValueSql("'1900-01-01T00:00:00.000'");
        }
    }
}
