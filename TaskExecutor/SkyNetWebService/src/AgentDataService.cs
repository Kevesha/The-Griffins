using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyNetWebService.Models;
using System.Data.SqlClient;
using Dapper;

namespace SkyNetWebService.src
{
    public class AgentDataService
    {
        private readonly string _connectionString;

        public AgentDataService(string LocalHost)
        {
            _connectionString = $"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog={LocalHost}";
        }

        public IEnumerable<ServiceAgents> GetAgents()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM dbo.Agent";
                var agents = connection.Query<ServiceAgents>(sql);
                return agents;
            }
        }
    }
}
