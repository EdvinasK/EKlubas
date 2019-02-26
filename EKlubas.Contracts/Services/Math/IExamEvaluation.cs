using System;
using System.Collections.Generic;
using System.Text;

namespace EKlubas.Contracts.Services.Math
{
    public interface IExamEvaluation
    {
        int UserCorrectAnswersCount { get; set; }
        int UserTotalAnswersCount { get; set; }
        int ExamCorrectAnswersCount { get; set; }
        int ExamTotalAnswersCount { get; set; }
    }
}
