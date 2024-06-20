using RehamAli.Models;

namespace RehamAli.Repos;

public interface ICandidateRepo
{
    public Task<int> CreateCandidateAsync(Candidate request);
    public Task<Candidate> GetCandidateByEmailAsync(string email);
    public Task<int> UpdateCandidateAsync(Candidate request);
}
