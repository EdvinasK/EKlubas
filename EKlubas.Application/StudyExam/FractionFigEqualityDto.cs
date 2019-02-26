using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class AnswerFormsDto
    {
        public Fraction Fraction { get; set; }
        public Fraction DrawingFraction { get; set; }

        public AnswerFormsDto() { }
        public AnswerFormsDto(Fraction fraction, Fraction drawingFraction)
        {
            Fraction = fraction;
            DrawingFraction = drawingFraction;
        }
    }
}
