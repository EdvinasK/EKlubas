using EKlubas.Contracts.Services.Math;
using EKlubas.UI.Services.Math.Commands.RealNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKlubas.UI.Services.Factories
{
    public static class EvaluationFactory
    {
        public static IEvaluateExamCommand<IExam> GetPrepareTaskCommand(string taskTypeName)
        {
            IEvaluateExamCommand<IExam> evaluateExamCommand = null;

            switch (taskTypeName)
            {
                case "RealNumber":
                    evaluateExamCommand = new EvaluateRnExamCommand();
                    break;
                default:
                    throw new ArgumentException("GetPrepareTaskCommand: Invalid prepare task command taskTypeName was used.");
            }

            return evaluateExamCommand;
        }
    }
}
