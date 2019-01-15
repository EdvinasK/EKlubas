using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Common.Services
{
    public static class MathServices
    {
        private static readonly Random getRandomNr = new Random();

        /// <summary>
        /// Calculates equation with provided calc and secondNumber variables with the provided string operator.
        /// </summary>
        /// <param name="calc">Variable which will store equation results.</param>
        /// <param name="secondNumber">Variable which will be worked with through the operation.</param>
        /// <param name="operatorSign">String operator sign which will be reconverted to calculatable form.</param>
        public static void SolveStringOperatorAbEquation(ref int calc, int secondNumber, string operatorSign)
        {
            calc = operatorSign == "+" ? calc + secondNumber
                                        : operatorSign == "-" ? calc - secondNumber
                                        : operatorSign == "/" ? calc / secondNumber
                                        : operatorSign == "*" ? calc * secondNumber
                                        : 0;
        }

        /// <summary>
        /// Finds if equation is true or not.
        /// </summary>
        /// <param name="firstNumber">Left side of equation.</param>
        /// <param name="secondNumber">Right side of equation.</param>
        /// <param name="equalitySign">Equality sign in string form.</param>
        /// <returns>Returns if equation is true or not.</returns>
        public static bool IsEquationTrue(int firstNumber, int secondNumber, string equalitySign)
        {
            return equalitySign == "<" ? firstNumber < secondNumber
                        : equalitySign == "&le;" ? firstNumber <= secondNumber
                        : equalitySign == ">" ? firstNumber > secondNumber
                        : equalitySign == "&ge;" ? firstNumber >= secondNumber
                        : equalitySign == "=" ? firstNumber == secondNumber
                        : false;
        }

        /// <summary>
        /// Calculates provided equation.
        /// </summary>
        /// <param name="firstNumber">Left side of equation.</param>
        /// <param name="secondNumber">Right side of equation.</param>
        /// <returns>Returns provided equation calculation.</returns>
        public static decimal CalculateEquation(int firstNumber, int secondNumber)
        {
            return secondNumber - firstNumber;
        }

        /// <summary>
        /// Gets a random math operator sign.
        /// </summary>
        /// <returns>Returns random math operator sign string.</returns>
        public static string GetRandomOperatorSign(bool isSimple = false)
        {
            var operatorSign = "";
            var operatorVariety = isSimple ? 2 : 4;

            switch (GetRandomNumber() % operatorVariety)
            {
                case 0:
                    operatorSign = "+";
                    break;
                case 1:
                    operatorSign = "-";
                    break;
                case 2:
                    operatorSign = "/";
                    break;
                case 3:
                    operatorSign = "*";
                    break;
                default:
                    operatorSign = ":D";
                    break;
            }

            return operatorSign;
        }

        /// <summary>
        /// Gets a random math equality sign.
        /// </summary>
        /// <returns>Returns random math equality sign string.</returns>
        public static string GetRandomEqualitySign()
        {
            var equalitySign = "";

            switch (GetRandomNumber() % 5)
            {
                case 0:
                    equalitySign = ">";
                    break;
                case 1:
                    equalitySign = "&ge;";
                    break;
                case 2:
                    equalitySign = "<";
                    break;
                case 3:
                    equalitySign = "&le;";
                    break;
                case 4:
                    equalitySign = "=";
                    break;
                default:
                    equalitySign = ":D";
                    break;
            }

            return equalitySign;
        }

        /// <summary>
        /// Gets a random number between 0 and 100.
        /// </summary>
        /// <returns>Returns a random number between 0 and 100.</returns>
        public static int GetRandomNumber()
        {
            return GetRandomNumber(0, 100);
        }

        /// <summary>
        /// Gets a random number between given min and max variables.
        /// </summary>
        /// <param name="min">Smallest possible random number.</param>
        /// <param name="max">Highest possible random number.</param>
        /// <returns>Gets a random number between given min and max variables</returns>
        public static int GetRandomNumber(int min, int max)
        {
            lock (getRandomNr)
            {
                return getRandomNr.Next(min, max);
            }
        }
    }
}
