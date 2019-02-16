using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class FinishedFractionExamResultDto : MathDoneDto
    {
        public FinishedFractionExamResultDto() : base() { }
        public FinishedFractionExamResultDto(Fraction fraction, Fraction drawingFraction) : base(fraction, drawingFraction) { }
    }
}
