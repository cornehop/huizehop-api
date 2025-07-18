using HuizeHop.Api.Library.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HuizeHop.Api.Library.Database;

/// <summary>
/// Database context for the HuizeHop API
/// </summary>
public class HuizeHopDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Account> Accounts { get; set; }

    public HuizeHopDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public HuizeHopDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("HuizeHopDb");
        if (string.IsNullOrEmpty(connectionString))
        {
            return;
        }
        
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureBaseEntities();
    }
}