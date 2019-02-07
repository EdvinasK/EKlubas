using EKlubas.Application;
using EKlubas.Common.Services;
using EKlubas.Domain;
using EKlubas.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.MathExam
{
    public class FractionEqualityExam
    {
        public async Task<EqualityExamDto<string>> PrepareExam(StudyTopic studyTopic,
                                                                    EKlubasUser user,
                                                                    ApplicationDbContext _context)
        {
            var equalityExam = new EqualityExamDto<string>();
            var fractionLeft = new Fraction();
            var fractionRight = new Fraction();
            int numerator, denominator = 0;
            var taskRandomizer = 0;
            var studyExam = new StudyExam(studyTopic.PassMark, studyTopic.Reward, studyTopic.DurationInMinutes, user, studyTopic.IsNew);

            for (int i = 0; i < 30; i++)
            {
                taskRandomizer = MathServices.GetRandomNumber();
                numerator = MathServices.GetRandomNumber(1, 5);
                denominator = MathServices.GetRandomNumber(0, 5) + numerator;

                fractionLeft.SetFractionInformation(numerator, denominator);

                if (taskRandomizer % 3 == 0)
                {
                    var fractionMultiplier = MathServices.GetRandomNumber(2, 5);
                    numerator = numerator * fractionMultiplier;
                    denominator = denominator * fractionMultiplier;

                    fractionRight.SetFractionInformation(numerator, denominator);
                }
                else
                {
                    numerator = MathServices.GetRandomNumber(1, 5);
                    denominator = MathServices.GetRandomNumber(0, 5) + numerator;

                    fractionRight.SetFractionInformation(numerator, denominator);
                }

                var answerId = Guid.NewGuid();
                var answer = fractionLeft.GetFractionDecimalForm() == fractionRight.GetFractionDecimalForm() ? "Teisinga" : "Neteisinga";

                var userAnswer = new StudyExamAnswer(answerId, answer);
                var fractionTask = $"{fractionLeft.GetFractionHtml()} = {fractionRight.GetFractionHtml()}";

                equalityExam.Tasks.Add(userAnswer.Id, fractionTask);
                studyExam.StudyExamResults.Add(userAnswer);
            }

            equalityExam.StudyExam = studyExam;
            await _context.StudyExams.AddAsync(studyExam);
            await _context.SaveChangesAsync();

            return equalityExam;
        }
    }
}
