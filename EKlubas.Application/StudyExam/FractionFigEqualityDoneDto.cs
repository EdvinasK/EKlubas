using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class FractionFigEqualityDoneDto : FractionFigEqualityDto
    {
        public Guid AnswerId { get; set; }

        public FractionFigEqualityDoneDto() : base() { }
        public FractionFigEqualityDoneDto(Fraction fraction, Fraction drawingFraction) : base(fraction, drawingFraction) { }
    }
}
