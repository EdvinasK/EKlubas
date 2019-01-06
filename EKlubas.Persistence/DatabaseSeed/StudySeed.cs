using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Persistence.DatabaseSeed
{
    public static class StudySeed
    {
        public static List<Study> GetStudyListSeed()
        {
            var studies = new List<Study>
            {
                new Study() { Id = 1, Name = "-Nepriskirta-" },
                new Study() { Id = 2, Name = "Matematika" }
            };

            return studies;
        }
    }
}
