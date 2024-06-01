using RehamAli.Controllers;
using RehamAli.Models;
using RehamAli.Repos;

namespace RehamAli.UnitTests.CandidateControllerTests;

public class PostCandidateTest(TestDatabaseFixture fixture) : IClassFixture<TestDatabaseFixture>
{
    public TestDatabaseFixture Fixture { get; } = fixture;


    [Fact]
    public async void PostCandidate_CandidateWithExistingEmailAndNewName_ExsistingCandidateNameUpdateExpected_1()
    {
        var candidate = new Candidate
        {
            Email = "user@example.com",
            FirstName = "Reem",
            LastName = "Ali",
            LinkedinProfileUrl = "",
            GithubProfileUrl = "",
            PhoneNumber = "01234567891",
            BetterDateToCall = new DateTime(2024, 6, 1),
            BetterStartHourToCall = 2,
            BetterEndHourToCall = 3,
            Comment = "Comment",
        };

        using var context = Fixture.CreateContext();
        context.Database.BeginTransaction();

        var controller = new CandidateController(new CandidateRepo(context));
        await controller.Post(candidate);

        context.ChangeTracker.Clear();

        var updatedCandidate = context.Candidates.Where(x => x.Email == candidate.Email).Single();
        Assert.Equal(candidate, updatedCandidate, (a,b) => a.Email == b.Email && a.FirstName == b.FirstName);
    }

    [Fact]
    public async void PostCandidate_CandidateWithExistingEmailAndNewName_ExsistingCandidateNameUpdateExpected_2()
    {
        var candidate = new Candidate
        {
            Email = "user@example.com",
            FirstName = "Reem",
            LastName = "Ali",
            LinkedinProfileUrl = "",
            GithubProfileUrl = "",
            PhoneNumber = "01234567891",
            BetterDateToCall = new DateTime(2024, 6, 1),
            BetterStartHourToCall = 2,
            BetterEndHourToCall = 3,
            Comment = "Comment",
        };

        using var context = Fixture.CreateContext();
        context.Database.BeginTransaction();

        var controller = new CandidateController(new CandidateRepo(context));
        await controller.Post(candidate);

        context.ChangeTracker.Clear();

        var candidateCount = context.Candidates.Count();
        Assert.Equal(2, candidateCount);
    }


    [Fact]
    public async void PostCandidate_CandidateWithNonExistingEmail_NewCandidateCreateExpected_3()
    {
        var candidate = new Candidate
        {
            Email = "newuser@example.com",
            FirstName = "Reem",
            LastName = "Ali",
            LinkedinProfileUrl = "",
            GithubProfileUrl = "",
            PhoneNumber = "01234567891",
            BetterDateToCall = new DateTime(2024, 6, 1),
            BetterStartHourToCall = 2,
            BetterEndHourToCall = 3,
            Comment = "Comment",
        };

        using var context = Fixture.CreateContext();
        context.Database.BeginTransaction();

        var controller = new CandidateController(new CandidateRepo(context));
        await controller.Post(candidate);

        context.ChangeTracker.Clear();

        var createdCandidate = context.Candidates.Where(x => x.Email == candidate.Email).Single();
        Assert.Equal(candidate, createdCandidate, (a, b) => a.Email == b.Email);
    }

    [Fact]
    public async void PostCandidate_CandidateWithNonExistingEmail_NewCandidateCreateExpected_4()
    {
        var candidate = new Candidate
        {
            Email = "newuser@example.com",
            FirstName = "Reem",
            LastName = "Ali",
            LinkedinProfileUrl = "",
            GithubProfileUrl = "",
            PhoneNumber = "01234567891",
            BetterDateToCall = new DateTime(2024, 6, 1),
            BetterStartHourToCall = 2,
            BetterEndHourToCall = 3,
            Comment = "Comment",
        };

        using var context = Fixture.CreateContext();
        context.Database.BeginTransaction();

        var controller = new CandidateController(new CandidateRepo(context));
        await controller.Post(candidate);

        context.ChangeTracker.Clear();

        var candidateCount = context.Candidates.Count();
        Assert.Equal(3, candidateCount);
    }

}
