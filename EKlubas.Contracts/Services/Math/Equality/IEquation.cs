using EKlubas.Domain.DTO;
using EKlubas.Domain.DTO.Classifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Services
{
    public interface IEquation
    {
        List<EquationResult<string, string>> GetEqualityTaskAndResult(
            int difficultyLevel,
            bool isVariableTask,
            bool isEqualityTask,
            int taskAmount);

        EquationMessage<string[], string> GetEqualityBuilderInput(
            TaskDifficulty difficulty,
            bool isVariableTask,
            bool isEqualityTask,
            int minTaskValue,
            int maxTaskValue);
    }
}
