using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKlubas.Core.Extensions;

namespace EKlubas.Persistence.Extensions
{
    public static class ModeBuilderExtensions
    {
        public static void PluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = InflectorExtensions.Pluralize(entity.DisplayName());
            }
        }
    }
}
