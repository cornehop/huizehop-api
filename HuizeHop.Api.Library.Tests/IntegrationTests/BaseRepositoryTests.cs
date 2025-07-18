using System.Data.Common;
using HuizeHop.Api.Library.Database.BaseClasses;
using HuizeHop.Api.Library.Tests.Mocks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HuizeHop.Api.Library.Tests.Database.BaseClasses;

public class BaseRepositoryTests
{
    private readonly DbConnection _connection;
    private ConfigurationMock _config;
    private DbContextOptions<DbContextMock> _contextOptions;

    public BaseRepositoryTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        
        _contextOptions = new DbContextOptionsBuilder<DbContextMock>().UseSqlite(_connection).Options;
    }
    
    DbContextMock CreateContext() => new DbContextMock(_config, _contextOptions);

    [Fact]
    public void Read_Returns_DatabaseEntity()
    {
        // Arrange
        using var dbContext = CreateContext();
        
        var someFieldTestValue = Guid.NewGuid().ToString();
        var anotherFieldTestValue = Guid.NewGuid().ToString();
        var newEntity = dbContext.MockEntities.Add(new MockEntity { SomeField = someFieldTestValue,  AnotherField = anotherFieldTestValue });
        dbContext.SaveChanges();
        
        var repository = new BaseRepository<MockEntity>(dbContext);
        
        // Act
        var result = repository.Read(newEntity.Entity.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(someFieldTestValue, result.SomeField);
        Assert.Equal(anotherFieldTestValue, result.AnotherField);
    }
}