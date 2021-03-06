﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EKlubas.Contracts.Services
{
    public interface IExamAnswer
    {
        string UserAnswer { get; set; }
        bool IsCorrect { get; set; }
        Guid TextAnswerId { get; set; }
    }
}
