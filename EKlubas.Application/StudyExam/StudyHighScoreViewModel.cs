using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class StudyHighScoreViewModel
    {
        public ICollection<StudyHighScoreDto> StudyHighScores { get; set; }
        public IEnumerable<StudyTopic> StudyTopics { get; set; }
    }
}
