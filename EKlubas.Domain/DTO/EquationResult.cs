using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain.DTO
{
    public class EquationResult <TMessage, TResult>
    {
        public TMessage Message { get; set; }
        public TResult Result { get; set; }
    }
}
