using Microsoft.EntityFrameworkCore;
using RehamAli.Models;

namespace RehamAli.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options)
{
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>().HasIndex(candidate => candidate.Email).IsUnique(true);
    }
}
