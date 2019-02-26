using EKlubas.Application;
using EKlubas.Contracts.Services;
using EKlubas.Contracts.Services.Math;
using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.MathExam
{
    public class EvalutateExam : IEvaluateExam
    {
        public Task<IExamEvaluation> Exec(IEnumerable<MathDoneDto> userAnswers, StudyExam studyExam, IEvaluateExamCommand prepareTaskCommand)
        {
            var examEvaluation = prepareTaskCommand.Exec(userAnswers, studyExam);

            return examEvaluation;
        }
    }
}
