using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain
{
    public class Study : Entity<int>
    {
        public string Name { get; set; }
        public ICollection<StudyTopic> StudyTopics { get; set; }
    }
}
