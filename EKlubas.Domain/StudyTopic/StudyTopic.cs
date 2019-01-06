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
        public string Link { get; set; }
        public string Topic { get; set; }
        public int DifficultyLevel { get; set; }
        public int DurationInMinutes { get; set; }

        public string DifficultyText
        {
            get
            {
                return GetDifficultyInText();
            }
        }
        public string DifficultyCssStyle
        {
            get
            {
                return GetDifficultyCssClass();
            }
        }

        public string GetDifficultyInText()
        {
            string difficulty;

            if (DifficultyLevel == 1)
                difficulty = "Labai lengvas";
            else if (DifficultyLevel == 2)
                difficulty = "Lengvas";
            else if (DifficultyLevel == 3)
                difficulty = "Vidutiniškas";
            else if (DifficultyLevel == 4)
                difficulty = "Sunkus";
            else if (DifficultyLevel == 5)
                difficulty = "Labai sunkus";
            else
                difficulty = "Nenustatyta";

            return difficulty;
        }

        public string GetDifficultyCssClass()
        {
            string difficulty;

            if (DifficultyLevel == 1)
                difficulty = "panel-success";
            else if (DifficultyLevel == 2)
                difficulty = "panel-warning";
            else if (DifficultyLevel == 3)
                difficulty = "panel-danger";
            else if (DifficultyLevel == 4)
                difficulty = "panel-danger";
            else if (DifficultyLevel == 5)
                difficulty = "panel-danger";
            else
                difficulty = "Nenustatyta";

            return difficulty;
        }
    }
}
