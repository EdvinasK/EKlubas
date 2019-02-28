using EKlubas.Contracts.Persistence;
using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services
{
    public interface IPrepareTaskCommand<TExam>
    {
        Task<TExam> ExecuteAsync(StudyExam studyExam, IApplicationDbContext context);
    }
}
