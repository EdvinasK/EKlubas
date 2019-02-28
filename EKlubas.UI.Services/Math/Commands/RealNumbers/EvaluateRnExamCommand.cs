using EKlubas.Application;
using EKlubas.Contracts.Services;
using EKlubas.Core.Extensions;
using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.Math.Commands
{
    public class EvaluateRnExamCommand : IEvaluateExamCommand
    {
        public IExamEvaluation Exec(IEnumerable<IExamAnswer> userAnswers, StudyExam studyExam) //TODO make this method async
        {
            foreach (var examAnswer in studyExam.StudyExamResults)
            {
                userAnswers.Where(ea => ea.UserAnswer == examAnswer.Answer && ea.TextAnswerId == examAnswer.Id).ForEach(ea => ea.IsCorrect = true);
            }

            var examEvaluation = new ExamEvaluation() { Score = 0 };

            var markCoefficient = (decimal)userAnswers.Where(ea => ea.IsCorrect).Count() * 100 / userAnswers.Count();


            examEvaluation.Score = Convert.ToInt32(System.Math.Round(markCoefficient));

            return examEvaluation;
        }
    }
}
