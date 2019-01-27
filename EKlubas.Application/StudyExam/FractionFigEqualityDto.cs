using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class FractionFigEqualityDto
    {
        public Fraction Fraction { get; set; }
        public Fraction DrawingFraction { get; set; }

        public FractionFigEqualityDto() { }
        public FractionFigEqualityDto(Fraction fraction, Fraction drawingFraction)
        {
            Fraction = fraction;
            DrawingFraction = drawingFraction;
        }
    }
}
