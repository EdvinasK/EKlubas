using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.StudyTopic
{
    public class StudyTopic : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
