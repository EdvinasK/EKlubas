using EKlubas.Contracts.Services.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKlubas.Application
{
    public class ExamEvaluation : IExamEvaluation
    {
        public int UserCorrectAnswersCount { get; set; }
        public int UserTotalAnswersCount { get; set; }
        public int ExamCorrectAnswersCount { get; set; }
        public int ExamTotalAnswersCount { get; set; }
    }
}
