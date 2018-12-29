using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.Identities
{
    public class IdentityRole : IdentityRole<string>
    {
        public IdentityRole()
        {

        }

        public string Description { get; set; }
    }
}
