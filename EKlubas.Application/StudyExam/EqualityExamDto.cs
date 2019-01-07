using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class EqualityExamDto
    {
        public EqualityExamDto()
        {
            Tasks = new Dictionary<Guid, string>();
        }

        public StudyExam StudyExam { get; set; }
        public Dictionary<Guid, string> Tasks { get; set; }
    }
}
