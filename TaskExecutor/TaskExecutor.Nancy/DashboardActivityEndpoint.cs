using Nancy;
using SkyNetWebService.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExecutor.Nancy
{
        public class DashboardActivityEndpoint : NancyModule
        {

            public DashboardActivityEndpoint(IDashboardDataService dashboardDataService)
            {
            GetDashboardActivities();
            }

            public void GetDashboardActivities()
            {
                Get["/dashboardActivity"] = _ =>
                {
                    var dashboardService = new DashboardDataService("DashboardActivities");
                    var getAllActivities = dashboardService.GetDashBoardActivities();
                    return Negotiate.WithStatusCode(HttpStatusCode.OK)
                            .WithModel(getAllActivities);

                };
            }
        }
    
}
