using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;
using static Nancy.Testing.ConfigurableBootstrapper;

namespace TaskExecutor.Nancy.Tests
{
    public class CustomBootstrapperTestWrapper : CustomBootstrapper
    {
        public CustomBootstrapperTestWrapper(Action<ConfigurableBootstrapperConfigurator> actions) : base(actions)
        {
        }
        public new void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(requestContainer, pipelines, context);
        }
    }
}