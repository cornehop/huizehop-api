using HuizeHop.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HuizeHop.Api.Tests.Controllers
{
    [TestClass]
    public class PingControllerTests
    {
        [TestMethod]
        public void Get_Should_Return_Ok()
        {
            var controller = new PingController();
            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}