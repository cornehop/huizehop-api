using HuizeHop.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HuizeHop.Api.Tests.Controllers;

public class PingControllerTests
{
    [Fact]
    public void Get_Should_Return_Ok()
    {
        // Arrange
        var controller = new PingController();
        
        // Act
        var result = controller.Index();
        
        // Assert
        Assert.IsType<OkResult>(result);
    }
}