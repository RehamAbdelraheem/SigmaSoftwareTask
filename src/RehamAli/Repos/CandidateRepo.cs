using Microsoft.EntityFrameworkCore;
using RehamAli.Data;
using RehamAli.Models;
using Serilog;

namespace RehamAli.Repos;

public class CandidateRepo(DatabaseContext context) : ICandidateRepo
{
    private readonly DatabaseContext _context = context;
    public async Task<int> CreateCandidateAsync(Candidate request)
    {
        try
        {
            request.Email = request.Email.Trim().ToLower();
            _context.Candidates.Add(request);
            await _context.SaveChangesAsync();

            return request.Id;
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            return default;
        }
    }

    public async Task<Candidate> GetCandidateByEmailAsync(string email)
    {
        try
        {
            var result = await _context.Candidates.Where(x => x.Email == email.Trim().ToLower()).FirstOrDefaultAsync();

            return result;
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            return default;
        }
    }

    public async Task<int> UpdateCandidateAsync(Candidate request)
    {
        try
        {
            request.Email = request.Email.Trim().ToLower();
            var candidate = await GetCandidateByEmailAsync(request.Email);
            candidate.Email = request.Email;
            candidate.FirstName = request.FirstName;
            candidate.LastName = request.LastName;
            candidate.LinkedinProfileUrl = request.LinkedinProfileUrl;
            candidate.GithubProfileUrl = request.GithubProfileUrl;
            candidate.BetterDateToCall = request.BetterDateToCall;
            candidate.BetterStartHourToCall = request.BetterStartHourToCall;
            candidate.BetterEndHourToCall = request.BetterEndHourToCall;
            candidate.Comment = request.Comment;
            
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();

            return request.Id;
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            return default;
        }
    }
}
