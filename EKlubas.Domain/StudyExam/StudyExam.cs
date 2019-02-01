using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain
{
    public class StudyExam : Entity<Guid>
    {
        public string UserId { get; set; }
        public EKlubasUser User { get; set; }
        public int PassMark { get; set; }
        public int Reward { get; set; }
        public bool IsNew { get; set; }
        public ICollection<StudyExamAnswer> StudyExamResults { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime EndDate { get; set; }

        public StudyExam()
        {
            StudyExamResults = new List<StudyExamAnswer>();
            Id = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }

        public StudyExam(int passMark, int reward, int examDurationInMin, EKlubasUser user, bool isNew) : this()
        {
            PassMark = passMark;
            Reward = reward;
            EndDate = DateTime.Now.AddMinutes(examDurationInMin);
            User = user;
            IsNew = isNew;
        }
    }
}
