using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Application
{
    public interface IFraction
    {
        void SetFractionInformation(int numerator, int denominator);
        decimal GetFractionDecimalForm(int fractionDigits);
        string GetFractionHtml();
    }
}
