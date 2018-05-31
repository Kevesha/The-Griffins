using Nancy;
using Nancy.ModelBinding;
using System;
using TaskExecutor.Nancy.Models;

namespace TaskExecutor.Nancy
{
    public class HostNameEndpoint : NancyModule
    {
        public HostNameEndpoint(IHostNameProcessor hostnameProcessor)
        {
            GetHostname(hostnameProcessor);
        }

        private void GetHostname(IHostNameProcessor hostnameProcessor)
        {
            Get["/hostname{fullyQualified}"] = parameters =>
            {
                try
                {
                    var fullyQualifiedQuery = this.Bind<fullyQualifiedModel>();
                    var hostname = hostnameProcessor.GetHostName();
                    if (fullyQualifiedQuery.fullyQualified)
                    {
                       hostname = hostnameProcessor.GetFullyQualifiedHostName();
                    }
               
                    var HostNameOutput = new MachineInformationResults
                    {
                        result = hostname
                    };
                    return Response.AsJson(HostNameOutput);
                
                }
                catch (Exception e)
                {
                    return HttpStatusCode.InternalServerError;
                }
            };
        }
    }
}
