using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace TaskExecutor.Nancy.Tests
{
    [TestFixture]
    public class AgentHistoryEndPointTest
    {
        [Test]
        public void GetAgentHistory_GivenAgentHistoryEndpoint_ShouldReturnStatusCode200()
        {
            // Arrange
            var browser = new Browser(with =>
            {
                with.Module<AgentHistoryEndPoint>();
            }, to => to.Accept("application/json"));

            // Act
            var result = browser.Get("/agentHistory", with => {
                with.HttpRequest();
            });

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

    }
}
