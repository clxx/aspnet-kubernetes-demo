using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using WebApi.Models;

namespace WebApi.Data
{
    public class StudentsContext : DbContext
    {
        private readonly ILogger<StudentsContext> _logger;

        public StudentsContext(DbContextOptions<StudentsContext> options, ILogger<StudentsContext> logger) : base(options)
        {
            _logger = logger;
        }

        public DbSet<Student> Students { get; set; }

        public async Task Initialize() =>
            // https://github.com/App-vNext/Polly/wiki/Retry
            // https://github.com/App-vNext/Polly/wiki/Asynchronous-action-execution
            await Policy
                .Handle<Exception>()
                .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(1), (exception, i, timeSpan) =>
                    _logger.LogWarning($"Polly retry number {i} after {timeSpan}: '{exception.Message}'."))
                .ExecuteAsync(async () =>
                {
                    await Database.EnsureDeletedAsync();
                    await Database.EnsureCreatedAsync();

                    await Students.AddRangeAsync(
                        new Student
                        {
                            FirstName = "Jeffery",
                            LastName = "Wilkins"
                        },
                        new Student
                        {
                            FirstName = "Jesse",
                            LastName = "Otis"
                        },
                        new Student
                        {
                            FirstName = "John",
                            LastName = "Ehrlich"
                        },
                        new Student
                        {
                            FirstName = "Elsa",
                            LastName = "Bond"
                        },
                        new Student
                        {
                            FirstName = "Rose",
                            LastName = "Pacheco"
                        },
                        new Student
                        {
                            FirstName = "Earl",
                            LastName = "Collins"
                        },
                        new Student
                        {
                            FirstName = "Robert",
                            LastName = "Brown"
                        },
                        new Student
                        {
                            FirstName = "Stella",
                            LastName = "Powers"
                        });

                    await SaveChangesAsync();
                });
    }
}
