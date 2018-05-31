using FluentAssertions;
using NUnit.Framework;
using SkyNetWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetWebService.src
{
    [TestFixture]
    public class DashboardServiceTests
    {
        [Test]
        public void GetActivities_WhenDataPresent_ShouldReturnCollectionOfDashboardActivities()
        {
            //---------------Arrange-------------------
            var dashboardDataService = new DashboardDataService("DashboardActivities");
            //---------------Act----------------------
            var activities = dashboardDataService.GetDashBoardActivities();

            var actualFirstAndLast = new List<DashboardService>
                {
                    activities.First(),
                    activities.Last()
                };
            //---------------Assert-----------------------
            var expectedFirstAndLast = new List<DashboardService>
                {
                    new DashboardService
                    {
                        Id = 1,
                        target="Dashboard",
                        action="Add Agent",
                        actionResult="Added Agent Smith",
                        Timestamp=DateTime.Parse("2018/05/28 9:45:37 PM").ToUniversalTime()
                    },
                    new DashboardService
                    {
                        Id = 2,
                        target="Agent Smith",
                        action="Executed Command",
                        actionResult="IP Address",
                        Timestamp=DateTime.Parse("2018/05/28 9:45:37 PM").ToUniversalTime()
                    }
                };
            Assert.AreEqual(2, activities.Count());
            actualFirstAndLast.Should().BeEquivalentTo(expectedFirstAndLast);
        }
    }
}
