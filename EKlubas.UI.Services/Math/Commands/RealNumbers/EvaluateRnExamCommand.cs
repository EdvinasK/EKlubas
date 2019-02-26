using EKlubas.Application;
using EKlubas.Contracts.Services.Math;
using EKlubas.Core.Extensions;
using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.Math.Commands.RealNumbers
{
    public class EvaluateRnExamCommand : IEvaluateExamCommand
    {
        public Task<IExamEvaluation> Exec(IEnumerable<IExamAnswer> userAnswers, StudyExam studyExam) //TODO make this method async
        {
            foreach (var examAnswer in studyExam.StudyExamResults)
            {
                userAnswers.Where(ea => ea.UserAnswer == examAnswer.Answer && ea.TextAnswerId == examAnswer.Id).ForEach(ea => ea.IsCorrect = true);
            }

            return null;
        }
    }
}
