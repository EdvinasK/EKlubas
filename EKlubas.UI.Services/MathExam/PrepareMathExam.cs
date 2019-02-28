using EKlubas.Application;
using EKlubas.Contracts.Persistence;
using EKlubas.Contracts.Services;
using EKlubas.Domain;
using EKlubas.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.UI.Services
{
    public class PrepareMathExam : IPrepareExam
    {
        public async Task<IExam> ExecuteAsync(StudyTopic studyTopic,
                                                EKlubasUser user,
                                                IApplicationDbContext _context,
                                                IPrepareTaskCommand<IExam> prepareTaskCommand)
        {
            var studyExam = new StudyExam(studyTopic.PassMark, studyTopic.Reward, studyTopic.DurationInMinutes, user, studyTopic.IsNew);

            var equalityTasksAndResults = await prepareTaskCommand.ExecuteAsync(studyExam, _context);

            return equalityTasksAndResults;
        }
    }
}
