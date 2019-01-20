using EKlubas.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class Fraction : IFraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() { }

        public Fraction(int numerator, int denominator)
        {
            SetFractionInformation(numerator, denominator);
        }

        /// <summary>
        /// Sets fraction numerator and denominator through a method call.
        /// </summary>
        /// <param name="numerator">Fractions numerator.</param>
        /// <param name="denominator">Fractions denominator.</param>
        public void SetFractionInformation(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Gets a comparable fractions decimal form.
        /// </summary>
        /// <param name="fractionDigits">The amount of digits which should go after comma.</param>
        /// <returns>Returns a comparable fractions decimal form.</returns>
        public decimal GetFractionDecimalForm(int fractionDigits = 2)
        {
            decimal result = (decimal)Numerator / Denominator;

            return Math.Round(result, 2);
        }

        /// <summary>
        /// Gets fraction HTML form.
        /// </summary>
        /// <returns>Returns fraction HTML form.</returns>
        public string GetFractionHtml()
        {
            return $"<sup>{Numerator}</sup>&frasl;<sub>{Denominator}</sub>";
        }
    }
}
