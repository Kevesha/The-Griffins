using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetWebService.Models
{
    public class DashboardService
    {
        public int Id { get; set; }
        public string target { get; set; }
        public string action { get; set; }
        public string actionResult { get; set; }
        public DateTime Timestamp { get; set; }
    
    }
}
