using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static object GetPropertyValue(this object source, string propertyName)
        {
            return source.GetType().GetProperties()
               .FirstOrDefault(pi => pi.Name == propertyName)
               ?.GetValue(source, null);
        }
    }
}
