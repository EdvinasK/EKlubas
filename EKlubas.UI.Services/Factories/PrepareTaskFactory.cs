using EKlubas.Contracts.Services;
using EKlubas.UI.Services.Math.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKlubas.UI.Services.Factories
{
    public static class PrepareTaskFactory
    {
        public static IPrepareTaskCommand<IExam> GetPrepareTaskCommand(string taskTypeName)
        {
            IPrepareTaskCommand<IExam> prepareTaskCommand = null;

            switch (taskTypeName)
            {
                case "RealNumber":
                    prepareTaskCommand = new PrepareRnTaskCommand();
                    break;
                default:
                    throw new ArgumentException("GetPrepareTaskCommand: Invalid prepare task command taskTypeName was used.");
            }

            return prepareTaskCommand;
        }
    }
}
