using EKlubas.Application;
using EKlubas.Domain;
using EKlubas.Persistence;
using EKlubas.UI.Services.Math.Equality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.MathExam
{
    public class EqualityExam
    {
        public async Task<EqualityExamDto<string>> PrepareExam(StudyTopic studyTopic, 
                                                                EKlubasUser user, 
                                                                ApplicationDbContext _context)
        {
            
            var mathTask = new Equation();
            var equalityTasks = new EqualityExamDto<string>();
            // var answerId = Guid.Empty;
            var studyExam = new StudyExam(studyTopic.PassMark, studyTopic.Reward, studyTopic.DurationInMinutes, user, studyTopic.IsNew);

            var equalityTasksAndResults = mathTask.GetEqualityTaskAndResult(studyTopic.DifficultyLevel);

            foreach (var task in equalityTasksAndResults)
            {
                var answerId = Guid.NewGuid();

                var userAnswer = new StudyExamAnswer(answerId, task.Result);

                equalityTasks.Tasks.Add(userAnswer.Id, task.Message);
                studyExam.StudyExamResults.Add(userAnswer);
            }

            equalityTasks.StudyExam = studyExam;

            await _context.StudyExams.AddAsync(studyExam);
            await _context.SaveChangesAsync();

            return equalityTasks;
        }
    }
}
