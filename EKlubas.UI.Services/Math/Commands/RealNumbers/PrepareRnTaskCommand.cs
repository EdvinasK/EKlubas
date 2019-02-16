using EKlubas.Application;
using EKlubas.Common.Services;
using EKlubas.Contracts.Persistence;
using EKlubas.Contracts.Services.Math;
using EKlubas.Domain;
using EKlubas.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.Math.Commands
{
    public class PrepareRnTaskCommand : IPrepareTaskCommand<IExam>
    {
        public async Task<IExam> ExecuteAsync(StudyExam studyExam, IApplicationDbContext context)
        {
            var rnExam = new MathExamDto();

            for (int i = 0; i < 30; i++)
            {
                var answerId = Guid.NewGuid();
                var taskSize = MathServices.GetRandomNumber(2, 4);
                var equationElements = new List<string>();

                for (var j = 0; j < taskSize; j++)
                {
                    var randomRealNumber = MathServices.GetRandomNumber(10, 1000) / 100.000m;
                    equationElements.Add(randomRealNumber.ToString());

                    if (j < taskSize-1)
                        equationElements.Add(MathServices.GetRandomOperatorSign(true));
                }

                var equation = string.Join(" ", equationElements);

                var correctAnswer = new StudyExamAnswer(answerId, new DataTable().Compute(equation, null).ToString());

                rnExam.Tasks.Add(correctAnswer.Id, equation);
                studyExam.StudyExamResults.Add(correctAnswer);
            }

            rnExam.StudyExam = studyExam;

            await context.StudyExams.AddAsync(studyExam);
            await context.SaveChangesAsync();

            return rnExam;
        }
    }
}
