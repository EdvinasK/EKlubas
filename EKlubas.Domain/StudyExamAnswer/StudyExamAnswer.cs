using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain
{
    public class StudyExamAnswer : Entity<Guid>
    {
        public string Answer { get; set; }
        public Guid StudyExamId { get; set; }
        public StudyExam StudyExam { get; set; }

        public StudyExamAnswer() { }
        public StudyExamAnswer(Guid id, string answer)
        {
            Id = id;
            Answer = answer;
        }
    }
}
