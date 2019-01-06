using EKlubas.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.StudyExamAnswer
{
    public class StudyExamAnswer : Entity<Guid>
    {
        public string Answer { get; set; }
        public string UserId { get; set; }
        public EKlubasUser User { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime EndDate { get; set; }
    }
}
