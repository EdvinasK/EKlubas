using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EKlubas.Domain
{
    public class EKlubasUser : IdentityUser<string>
    {
        public string Nickname { get; set; }
        public DateTime BirthYear { get; set; }
        public int Coins { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<StudyExamAnswer> StudyExamAnswers { get; set; }
    }
}
