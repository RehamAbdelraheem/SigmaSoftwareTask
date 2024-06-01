using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RehamAli.Data;
using RehamAli.Models;

namespace RehamAli.UnitTests;

public class TestDatabaseFixture
{
    private const string ConnectionString = "Server=.;Database=CandidatesTest;Trusted_Connection=True;TrustServerCertificate=Yes;";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.AddRange(
                        new Candidate {
                            Email = "user@example.com",
                            FirstName = "Reham",
                            LastName = "Ali",
                            LinkedinProfileUrl = "",
                            GithubProfileUrl = "",
                            PhoneNumber = "01234567891",
                            BetterDateToCall = new DateTime(2024, 6, 1),
                            BetterStartHourToCall = 2,
                            BetterEndHourToCall = 3,
                            Comment = "Comment",
                        },
                        new Candidate
                        {
                            Email = "test@test.test",
                            FirstName = "Rania",
                            LastName = "Ahmed",
                            LinkedinProfileUrl = "",
                            GithubProfileUrl = "",
                            PhoneNumber = "01234567891",
                            BetterDateToCall = new DateTime(2024, 6, 1),
                            BetterStartHourToCall = 2,
                            BetterEndHourToCall = 3,
                            Comment = "Comment",
                        });

                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public DatabaseContext CreateContext()
    {
        return new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer(ConnectionString).Options);
    }
}
