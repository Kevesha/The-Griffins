using Nancy;
using Nancy.Testing;
using NSubstitute;
using NUnit.Framework;
using SkyNetWebService.Models;
using SkyNetWebService.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskExecutorBoundry;

namespace TaskExecutor.Nancy.Tests
{
    [TestFixture]
    public class DashBoardActivityTests
    {
        [Test]
        public void GetAgentHistory_GivenAgentHistoryEndpoint_ShouldReturnStatusCode200()
        {
            // Arrange
            var dataService = Substitute.For<IDashboardDataService>();
            IEnumerable<DashboardService> dashboardActivities = new List<DashboardService>()
            {
                new DashboardService
                {
                        Id = 1,
                        target="Dashboard",
                        action="Add Agent",
                        actionResult="Added Agent Smith",
                        Timestamp=DateTime.Parse("2018/05/28 9:45:37 PM").ToUniversalTime()
                }
            };
            dataService.GetDashBoardActivities().Returns(dashboardActivities);
            var browser = new Browser(with =>
            {
                with.Module<DashboardActivityEndpoint>();
            }, to => to.Accept("application/json"));

            // Act
            var result = browser.Get("/dashboardActivity", with =>
            {
                with.HttpRequest();
            });

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //Assert
          

        }
    }
}
