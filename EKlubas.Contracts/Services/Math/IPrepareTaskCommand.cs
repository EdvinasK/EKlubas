using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services.Math
{
    public interface IPrepareTaskCommand<TExam, TDb>
    {
        Task<TExam> ExecAsync(StudyExam studyExam, TDb context);
    }
}
