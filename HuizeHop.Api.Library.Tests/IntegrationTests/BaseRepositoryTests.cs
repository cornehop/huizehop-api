using HuizeHop.Api.Library.Database.BaseClasses;
using HuizeHop.Api.Library.Tests.Mocks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HuizeHop.Api.Library.Tests.IntegrationTests;

public class BaseRepositoryTests
{
    private readonly DbContextOptions<DbContextMock> _contextOptions;

    public BaseRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        
        _contextOptions = new DbContextOptionsBuilder<DbContextMock>().UseSqlite(connection).Options;

        using var context = new DbContextMock(_contextOptions);
        context.Database.EnsureCreated();
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
    
    [Fact]
    public void Read_Returns_Null_WhenEntityDoesNotExist()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        var nonExistingId = Guid.NewGuid();
        
        var repository = new BaseRepository<MockEntity>(dbContext);
        
        // Act
        var result = repository.Read(nonExistingId);
        
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Create_Returns_NewEntity()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        var newEntity = new MockEntity {  SomeField = Guid.NewGuid().ToString(), AnotherField = Guid.NewGuid().ToString() };
        var repository = new BaseRepository<MockEntity>(dbContext);
        
        // Act
        var result = repository.Create(newEntity);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal(newEntity.SomeField, result.SomeField);
        Assert.Equal(newEntity.AnotherField, result.AnotherField);
        
        var dbEntity = dbContext.MockEntities.Single();
        Assert.Equal(newEntity.SomeField, dbEntity.SomeField);
        Assert.Equal(newEntity.AnotherField, dbEntity.AnotherField);
    }
    
    [Fact]
    public void Update_Returns_UpdatedEntity()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        var newEntity = new MockEntity {  SomeField = Guid.NewGuid().ToString(), AnotherField = Guid.NewGuid().ToString() };
        dbContext.MockEntities.Add(newEntity);
        dbContext.SaveChanges();
        var repository = new BaseRepository<MockEntity>(dbContext);
        var newValue = Guid.NewGuid().ToString();
        var newValue2 = Guid.NewGuid().ToString();
        
        // Act
        newEntity.SomeField = newValue;
        newEntity.AnotherField = newValue2;
        var result = repository.Update(newEntity);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(newValue, result.SomeField);
        Assert.Equal(newValue2, result.AnotherField);
        
        var dbEntity = dbContext.MockEntities.Single();
        Assert.Equal(newEntity.SomeField, dbEntity.SomeField);
        Assert.Equal(newEntity.AnotherField, dbEntity.AnotherField);
    }

    [Fact]
    public void Delete_RemovesEntity()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        var newEntity = new MockEntity {  SomeField = Guid.NewGuid().ToString(), AnotherField = Guid.NewGuid().ToString() };
        dbContext.MockEntities.Add(newEntity);
        dbContext.SaveChanges();
        var repository = new BaseRepository<MockEntity>(dbContext);
        
        // Act
        repository.Delete(newEntity.Id);
        
        // Assert
        var items = dbContext.MockEntities.ToList();
        Assert.Empty(items);
    }

    [Fact]
    public void Delete_IgnoresNonExistingEntity()
    {
        // Arrange
        using var dbContext = new DbContextMock(_contextOptions);
        var newEntity = new MockEntity {  SomeField = Guid.NewGuid().ToString(), AnotherField = Guid.NewGuid().ToString() };
        dbContext.MockEntities.Add(newEntity);
        dbContext.SaveChanges();
        var repository = new BaseRepository<MockEntity>(dbContext);
        
        // Act
        repository.Delete(Guid.NewGuid());
        
        // Assert
        var items = dbContext.MockEntities.ToList();
        Assert.NotEmpty(items);
    }
}