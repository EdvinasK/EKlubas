using EKlubas.Application;
using EKlubas.Contracts.Services.Math;
using EKlubas.Domain;
using EKlubas.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services.MathExam
{
    public class PrepareMathExam
    {
        public async Task<EqualityExamDto<string>> ExecuteAsync(StudyTopic studyTopic,
                                                                EKlubasUser user,
                                                                ApplicationDbContext _context,
                                                                IPrepareTaskCommand<EqualityExamDto<string>, ApplicationDbContext> prepareTaskCommand)
        {
            var studyExam = new StudyExam(studyTopic.PassMark, studyTopic.Reward, studyTopic.DurationInMinutes, user, studyTopic.IsNew);

            var equalityTasksAndResults = await prepareTaskCommand.ExecAsync(studyExam, _context);

            return equalityTasksAndResults;
        }
    }
}
