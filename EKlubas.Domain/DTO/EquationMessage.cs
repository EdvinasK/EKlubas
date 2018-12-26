using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.DTO
{
    public class EquationMessage <TValues, TInfo>
    {
        public TValues ReturnValues { get; set; }
        public TInfo Information { get; set; }
    }
}
