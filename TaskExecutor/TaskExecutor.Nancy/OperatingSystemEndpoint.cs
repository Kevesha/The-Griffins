using Nancy;
using Nancy.ModelBinding;
using System;
using TaskExecutor.Nancy.Models;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace TaskExecutor.Nancy
{
    public class OperatingSystemEndpoint : NancyModule
    {
        public OperatingSystemEndpoint(IOperatingSystemProcessor operatingSystemProcessor)
        {
           
            GetOperatingSystem(operatingSystemProcessor);
        }

        public void GetOperatingSystem(IOperatingSystemProcessor operatingSystemProcessor)
        {
            Get["/os"] = parameters =>
            {
                try
                {
                    var operatingSystem = operatingSystemProcessor.GetOperatingSystem();
                    var operatingSystemOutput = new MachineInformationResults
                    {
                        result = operatingSystem
                    };
                return Response.AsJson(operatingSystemOutput);
            }
                catch(Exception e)
                {
                    return HttpStatusCode.InternalServerError;
                }
 
            };
        }
    }
}
