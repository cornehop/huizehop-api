using System.Data.Common;
using HuizeHop.Api.Library.Database;
using HuizeHop.Api.Library.Database.BaseClasses;
using HuizeHop.Api.Library.Tests.Mocks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HuizeHop.Api.Library.Tests.IntegrationTests;

public class BaseRepositoryTests
{
    private DbContextOptions<DbContextMock> _contextOptions;

    public BaseRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        
        _contextOptions = new DbContextOptionsBuilder<DbContextMock>().UseSqlite(connection).Options;

        using (var context = new DbContextMock(_contextOptions))
        {
            context.Database.EnsureCreated();
        }
    }

    [Fact]
    public void Read_Returns_DatabaseEntity()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        
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