using Microsoft.AspNetCore.Mvc;
using RehamAli.Models;
using RehamAli.Repos;
using Serilog;

namespace RehamAli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController(ICandidateRepo candidateRepo) : ControllerBase
{
    private readonly ICandidateRepo _candidateRepo = candidateRepo;

    [HttpPost(Name = "PostCandidate")]
    public async Task<IActionResult> Post([FromBody] Candidate request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidate = await _candidateRepo.GetCandidateByEmailAsync(request.Email);
            int result;
            if (candidate != null)
            {
                result = await _candidateRepo.UpdateCandidateAsync(request);
            }
            else
            {
                result = await _candidateRepo.CreateCandidateAsync(request);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            return Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
