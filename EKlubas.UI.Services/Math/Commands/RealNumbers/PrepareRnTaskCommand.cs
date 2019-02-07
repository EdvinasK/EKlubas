using EKlubas.Application;
using EKlubas.Contracts.Services.Math;
using EKlubas.Domain;
using EKlubas.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.Math.Commands.RealNumbers
{
    public class PrepareRnTaskCommand : IPrepareTaskCommand<MathExamDto, ApplicationDbContext>
    {
        public async Task<MathExamDto> ExecAsync(StudyExam studyExam, ApplicationDbContext context)
        {
            var rnExam = new MathExamDto();

            for (int i = 0; i < 30; i++)
            {
                var answerId = Guid.NewGuid();

                var userAnswer = new StudyExamAnswer(answerId, "This is the answer");

                rnExam.Tasks.Add(userAnswer.Id, "This is the task");
                studyExam.StudyExamResults.Add(userAnswer);
            }

            rnExam.StudyExam = studyExam;

            await context.StudyExams.AddAsync(studyExam);
            await context.SaveChangesAsync();

            return rnExam;
        }
    }
}
