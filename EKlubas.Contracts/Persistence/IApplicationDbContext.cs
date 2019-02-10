using EKlubas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EKlubas.Contracts.Persistence
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<City> Cities { get; set; }
        DbSet<StudyTopic> StudyTopics { get; set; }
        DbSet<StudyExamAnswer> StudyExamAnswers { get; set; }
        DbSet<Study> Studies { get; set; }
        DbSet<StudyExam> StudyExams { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
