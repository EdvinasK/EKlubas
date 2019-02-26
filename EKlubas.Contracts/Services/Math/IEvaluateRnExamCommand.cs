using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services.Math
{
    public interface IEvaluateExamCommand
    {
        Task<IExamEvaluation> Exec(IEnumerable<IExamAnswer> userAnswers, StudyExam studyExam);
    }
}
