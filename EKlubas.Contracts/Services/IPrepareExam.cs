using EKlubas.Contracts.Persistence;
using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services
{
    public interface IPrepareExam
    {
        Task<IExam> ExecuteAsync(StudyTopic studyTopic, EKlubasUser user, IApplicationDbContext _context,
                                            IPrepareTaskCommand<IExam> prepareTaskCommand);
    }
}
