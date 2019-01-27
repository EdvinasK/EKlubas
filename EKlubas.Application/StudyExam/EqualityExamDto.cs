using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class EqualityExamDto<TTask>
    {
        public EqualityExamDto()
        {
            Tasks = new Dictionary<Guid, TTask>();
        }

        public StudyExam StudyExam { get; set; }
        public Dictionary<Guid, TTask> Tasks { get; set; }
    }
}
