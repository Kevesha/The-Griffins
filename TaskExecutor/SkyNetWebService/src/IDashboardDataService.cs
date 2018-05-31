using System.Collections.Generic;
using SkyNetWebService.Models;

namespace SkyNetWebService.src
{
    public interface IDashboardDataService
    {
        IEnumerable<DashboardService> GetDashBoardActivities();
    }
}