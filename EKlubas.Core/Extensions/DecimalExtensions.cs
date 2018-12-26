using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Core.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToDecimal(this object value)
        {
            if (null == value)
                return 0.00m;

            try
            {
                return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return 0.00m;
            }
        }
    }
}
