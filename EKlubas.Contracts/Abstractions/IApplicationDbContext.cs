using EKlubas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<StudyTopic> StudyTopics { get; set; }
        DbSet<StudyExamAnswer> StudyExamAnswers { get; set; }
        DbSet<Study> Studies { get; set; }
    }
}
