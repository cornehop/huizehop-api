namespace HuizeHop.Api.Tests.Controllers
{
    [TestClass]
    public class PingControllerTests
    {
        [TestMethod]
        public void Get_Should_Return_Ok()
        {
            var controller = new PingController();
        }
    }
}