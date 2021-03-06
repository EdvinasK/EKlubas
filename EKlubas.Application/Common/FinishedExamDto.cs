﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Application
{
    public class FinishedExamDto<TAnswers>
    {
        public FinishedExamDto()
        {
            ExamAnswers = new List<TAnswers>();
        }

        public Guid ExamId { get; set; }
        public List<TAnswers> ExamAnswers { get; set; }
    }
}
