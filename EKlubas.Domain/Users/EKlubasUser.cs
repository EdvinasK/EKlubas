using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKlubas.Domain.CityNS;
using Microsoft.AspNetCore.Identity;

namespace EKlubas.Domain.Users
{
    public class EKlubasUser : IdentityUser<string>
    {
        public string Nickname { get; set; }
        public DateTime BirthYear { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
