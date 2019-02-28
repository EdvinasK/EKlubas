using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKlubas.Common.Services;
using EKlubas.Contracts.Services;
using EKlubas.Domain;
using EKlubas.Domain.DTO;
using EKlubas.Domain.DTO.Classifiers;

namespace EKlubas.UI.Services
{
    public class Equation : IEquation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskAmount"></param>
        /// <param name="difficultyVariety">Currenly goes up to 8 and gives different difficulty tasks.</param>
        /// <returns></returns>
        public List<EquationResult<string, string>> GetEqualityTaskAndResult(
            int difficultyLevel,
            bool isVariableTask = false,
            bool isEqualityTask = true,
            int taskAmount = 30)
        {
            var tasks = new List<EquationResult<string, string>>();
            var equationMessage = new EquationMessage<string[], string>();
            var equalityTaskTextBuilder = new StringBuilder();
            var stringBuildFormat = "";
            var taskFormatRandomizer = 0;
            int difficultyVariety = difficultyLevel == 1 ? 4
                                        : difficultyLevel == 2 ? 7
                                        : 8;



            for (int i = 0; i < taskAmount; i++)
            {
                var equationResult = new EquationResult<string, string>();

                taskFormatRandomizer = MathServices.GetRandomNumber(1, difficultyVariety);
                if (taskFormatRandomizer == 1)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.Easiest, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2}";

                }
                else if (taskFormatRandomizer == 2)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.VeryEasy, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4}";
                }
                else if (taskFormatRandomizer == 3)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.Easy, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4}";
                }
                else if (taskFormatRandomizer == 4)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.Medium, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4} {5} {6}";
                }
                else if (taskFormatRandomizer == 5)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.Hard, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4} {5} {6} {7} {8}";
                }
                else if (taskFormatRandomizer == 6)
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.Harder, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4} {5} {6} {7} {8}";
                }
                else
                {
                    equationMessage = GetEqualityBuilderInput(TaskDifficulty.VeryHard, isVariableTask, isEqualityTask);
                    stringBuildFormat = "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}";
                }

                equalityTaskTextBuilder.AppendFormat(stringBuildFormat,
                                                                equationMessage.ReturnValues);

                if (!isVariableTask && isEqualityTask)
                    equationResult.Result = "Ats: " + (equationMessage.Information == "True" ? "Teisinga" : "Neteisinga");
                else if (isVariableTask && !isEqualityTask)
                    equationResult.Result = "Ats: X yra " + equationMessage.Information;
                else
                    equationResult.Result = "Ats: X " + equationMessage.Information;

                equationResult.Message = equalityTaskTextBuilder.ToString();
                tasks.Add(equationResult);
                equalityTaskTextBuilder.Clear();
            }

            return tasks;
        }

        /// <summary>
        /// Builds required input for equality task StringBuilder.
        /// </summary>
        /// <param name="difficulty">Difficulty of the specified task.</param>
        /// <returns>Returns equality task string array.</returns>
        public EquationMessage<string[], string> GetEqualityBuilderInput(TaskDifficulty difficulty,
                                                                            bool isVariableTask = false,
                                                                            bool isEqualityTask = true,
                                                                            int minTaskValue = 1,
                                                                            int maxTaskValue = 10)
        {
            var message = new EquationMessage<string[], string>();
            var input = new StringBuilder();
            var leftSideCalc = 0;
            var rightSideCalc = 0;
            var tempRandNumber = "0";
            var tempSign = "";
            var tempEqualSign = "";

            tempRandNumber = !isVariableTask ? MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString() : "x";
            leftSideCalc = !isVariableTask ? int.Parse(tempRandNumber) : 0;
            input.Append(tempRandNumber + ' ');

            if (difficulty == TaskDifficulty.VeryEasy ||
                difficulty == TaskDifficulty.Medium ||
                difficulty == TaskDifficulty.Hard ||
                difficulty == TaskDifficulty.Harder ||
                difficulty == TaskDifficulty.VeryHard)
            {
                tempSign = MathServices.GetRandomOperatorSign(isVariableTask);
                tempRandNumber = MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString();
                MathServices.SolveStringOperatorAbEquation(ref leftSideCalc, int.Parse(tempRandNumber), tempSign);

                input.Append(tempSign + ' ');
                input.Append(tempRandNumber + ' ');

                if (difficulty == TaskDifficulty.Hard ||
                    difficulty == TaskDifficulty.VeryHard)
                {
                    tempSign = MathServices.GetRandomOperatorSign(isVariableTask);
                    tempRandNumber = MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString();
                    MathServices.SolveStringOperatorAbEquation(ref leftSideCalc, int.Parse(tempRandNumber), tempSign);
                    input.Append(tempSign + ' ');
                    input.Append(tempRandNumber + ' ');
                }
            }

            tempEqualSign = isEqualityTask ? MathServices.GetRandomEqualitySign() : "=";
            tempRandNumber = MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString();
            rightSideCalc = int.Parse(tempRandNumber);
            input.Append(tempEqualSign + ' ');
            input.Append(tempRandNumber + ' ');

            if (difficulty == TaskDifficulty.Easy ||
                difficulty == TaskDifficulty.Medium ||
                difficulty == TaskDifficulty.Hard ||
                difficulty == TaskDifficulty.Harder ||
                difficulty == TaskDifficulty.VeryHard)
            {
                tempSign = MathServices.GetRandomOperatorSign(isVariableTask);
                tempRandNumber = MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString();
                MathServices.SolveStringOperatorAbEquation(ref rightSideCalc, int.Parse(tempRandNumber), tempSign);
                input.Append(tempSign + ' ');
                input.Append(tempRandNumber + ' ');

                if (difficulty == TaskDifficulty.Harder ||
                    difficulty == TaskDifficulty.VeryHard)
                {
                    tempSign = MathServices.GetRandomOperatorSign(isVariableTask);
                    tempRandNumber = MathServices.GetRandomNumber(minTaskValue, maxTaskValue).ToString();
                    MathServices.SolveStringOperatorAbEquation(ref rightSideCalc, int.Parse(tempRandNumber), tempSign);
                    input.Append(tempSign + ' ');
                    input.Append(tempRandNumber + ' ');
                }
            }

            message.ReturnValues = input.ToString().Trim(' ').Split(' ').ToArray();

            if (!isVariableTask && isEqualityTask)
                message.Information = MathServices.IsEquationTrue(leftSideCalc, rightSideCalc, tempEqualSign).ToString();
            else if (isVariableTask && !isEqualityTask)
                message.Information = MathServices.CalculateEquation(leftSideCalc, rightSideCalc).ToString();
            else
                message.Information = tempEqualSign + " " + MathServices.CalculateEquation(leftSideCalc, rightSideCalc).ToString();

            return message;
        }
    }
}
