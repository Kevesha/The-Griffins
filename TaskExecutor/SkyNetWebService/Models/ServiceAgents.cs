using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNetWebService.Models
{
    public class ServiceAgents
    {
        public int Id { get; set; }
        public string command { get; set; }
        public string result { get; set; }
        public DateTime executionTimeStamp { get; set; }
    }
}
