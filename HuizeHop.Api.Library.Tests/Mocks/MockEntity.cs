using HuizeHop.Api.Library.Database.BaseClasses;

namespace HuizeHop.Api.Library.Tests.Mocks;

public class MockEntity : BaseEntity
{
    public required string SomeField { get; set; }
    public required string AnotherField { get; set; }
}