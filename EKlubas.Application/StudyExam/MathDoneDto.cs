using EKlubas.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class MathDoneDto : AnswerFormsDto, IExamAnswer
    {
        public Guid AnswerId { get; set; }
        public Guid TextAnswerId { get; set; }
        public string HtmlTask { get; set; }
        public bool IsCorrect { get; set; }
        public string CorrectAnswer { get; set; }
        private string _userAnswer;
        public string UserAnswer
        {
            get { return _userAnswer; }
            set { _userAnswer = string.Format("{0:0.00}", value.Replace(",",".")); }
        }

        public MathDoneDto() : base() { }
        public MathDoneDto(Fraction fraction, Fraction drawingFraction) : base(fraction, drawingFraction) { }
    }
}
