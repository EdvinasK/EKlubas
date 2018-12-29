using EKlubas.Domain.CityNS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }
    }
}
