using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class FractionEqualityDoneDto : FractionFigEqualityDto
    {
        public Guid AnswerId { get; set; }
        public Guid TextAnswerId { get; set; }
        public string HtmlTask { get; set; }
        public bool IsCorrect { get; set; }

        public FractionEqualityDoneDto() : base() { }
        public FractionEqualityDoneDto(Fraction fraction, Fraction drawingFraction) : base(fraction, drawingFraction) { }
    }
}
