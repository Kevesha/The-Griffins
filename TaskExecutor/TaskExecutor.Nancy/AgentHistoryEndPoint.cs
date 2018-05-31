using Nancy;
using SkyNetWebService.src;
using TaskExecutorBoundry;

namespace TaskExecutor.Nancy
{
    public class AgentHistoryEndPoint : NancyModule
    {
        public AgentHistoryEndPoint()
        {
            GetAgentHistory();
        }

        public void GetAgentHistory()
        {
            Get["/agentHistory"] = _ =>
            {
                var agentService = new AgentDataService("LocalHost");
                var getAllAgent = agentService.GetAgents();
                return Negotiate.WithStatusCode(HttpStatusCode.OK)
                        .WithModel(getAllAgent);

            };
        }
    }
}
