using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SkyNetWebService.Models;

namespace SkyNetWebService.Tests
{
   [TestFixture]
   public class AgentDataServiceTest
    {
        [Test]
        public void GetAgents_WhenDataPresent_ShouldReturnCollectionOfAgents()
        {
            //---------------Arrange-------------------
            var agentDataService = new src.AgentDataService("LocalHost");
            //---------------Act----------------------
            var agents = agentDataService.GetAgents();

            var actualFirstAndLast = new List<ServiceAgents>
                {
                    agents.First(),
                    agents.Last()
                };
            //---------------Assert-----------------------
            var expectedFirstAndLast = new List<ServiceAgents>
                {
                    new ServiceAgents
                    {
                        Id = 1,
                        command="hostname",
                        result="DevFluence-DBN1",
                        executionTimeStamp= DateTime.Parse("2018/05/28 9:45:37 PM").ToUniversalTime()

                        
                    },
                    new ServiceAgents
                    {
                        Id = 2,
                        command="hostname",
                        result="DevFluence-DBN2",
                        executionTimeStamp= DateTime.Parse("2018/06/28 9:45:37 PM").ToUniversalTime()

                    }
                };
            Assert.AreEqual(2, agents.Count());
            actualFirstAndLast.Should().BeEquivalentTo(expectedFirstAndLast);
        }
    }
}
