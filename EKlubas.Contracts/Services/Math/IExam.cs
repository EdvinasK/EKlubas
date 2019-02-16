using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services.Math
{
    public interface IExam
    {
        StudyExam StudyExam { get; set; }
        Dictionary<Guid, string> Tasks { get; set; }
    }
}
