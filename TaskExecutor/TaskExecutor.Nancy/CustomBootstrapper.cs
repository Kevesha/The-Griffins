using Nancy;
using Nancy.Bootstrapper;
using Nancy.Testing;
using Nancy.TinyIoc;
using System;
using System.Text;

namespace TaskExecutor.Nancy
{
    public class CustomBootstrapper : ConfigurableBootstrapper
    {
        public CustomBootstrapper(Action<ConfigurableBootstrapperConfigurator> actions) : base(actions) { }

        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline((nancyContext, exception) =>
            {
                var errorBytes = Encoding.UTF8.GetBytes(exception.Message);
                return new Response
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ContentType = "powerShellScript/plain",
                    Contents = stream => stream.Write(errorBytes, 0, errorBytes.Length)
                };
            });

            base.RequestStartup(requestContainer, pipelines, context);
        }
    }
}
