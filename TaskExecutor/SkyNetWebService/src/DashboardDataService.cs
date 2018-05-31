using Dapper;
using SkyNetWebService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetWebService.src
{
    public class DashboardDataService : IDashboardDataService
    {
        private readonly string _connectionString;
        public DashboardDataService()
        {
            _connectionString = $"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=DashboardActivities";
        }

        public DashboardDataService(string DashboardActivities)
        {
            _connectionString = $"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog={DashboardActivities}";
        }

        public IEnumerable<DashboardService> GetDashBoardActivities()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM dbo.Activities";
                var activities = connection.Query<DashboardService>(sql);
                return activities;
            }
        }
    }
}
