using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services
{
    public interface IEvaluateExamCommand
    {
        IExamEvaluation Exec(IEnumerable<IExamAnswer> userAnswers, StudyExam studyExam);
    }
}
