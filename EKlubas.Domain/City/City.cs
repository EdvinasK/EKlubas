using EKlubas.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.CityNS
{
    public class City : Entity<int>
    {
        public string Name { get; set; }
        public ICollection<EKlubasUser> Users { get; set; }
    }
}
