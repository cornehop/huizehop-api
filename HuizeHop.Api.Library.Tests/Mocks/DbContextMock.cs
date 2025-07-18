using HuizeHop.Api.Library.Database;
using HuizeHop.Api.Library.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HuizeHop.Api.Library.Tests.Mocks;

public class DbContextMock : DbContext
{
    // Database sets
    public DbSet<MockEntity> MockEntities { get; set; }
    
    /// <summary>
    /// Default constructor just to mock the context without any database
    /// </summary>
    public DbContextMock() { }

    /// <summary>
    /// Constructor for the mock with a SQLite in-memory database
    /// </summary>
    /// <param name="options">Options to use for SQLite in memory databases</param>
    public DbContextMock(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        return;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureBaseEntities();
        modelBuilder.Entity<MockEntity>();
    }
}