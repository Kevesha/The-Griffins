using Nancy.Hosting.Self;
using Nancy.Testing;
using Nancy.TinyIoc;
using SkyNetWebService.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskExecutor;
using TaskExecutor.Nancy;
using TaskExecutorBoundry;

namespace TaskExecutorNancyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;
            var bootstrapper = CreateConfigurableBootstrapper();

            Uri uri = new Uri("http://localhost:1234/api/");
            var host = new NancyHost(bootstrapper, hostConfigs, uri);

            host.Start();
            Console.ReadKey();

        }

        private static ConfigurableBootstrapper CreateConfigurableBootstrapper()
        {
            var bootstrapper = new CustomBootstrapper(with =>
            {
                with.Module<HealthEndpoint>();
                with.Module<HostNameEndpoint>();
                with.Module<IpEndpoint>();
                with.Module<OperatingSystemEndpoint>();
                with.Module<PowershellScriptEndpoint>();
                with.Module<AgentHistoryEndPoint>();
                with.Module<DashboardActivityEndpoint>();
                with.Dependency<IHostNameProcessor>(typeof(HostNameProcessor));
                with.Dependency<IDashboardDataService>(typeof(DashboardDataService));
                with.Dependency<IIpAddressProcessor>(typeof(IpAddressProcessor));
                with.Dependency<IOperatingSystemProcessor>(typeof(OperatingSystemProcessor));
                with.Dependency<IPowershellScript>(typeof(NancyPowershellScript));
                with.Dependency<IScript>(typeof(Script));

            });
            return bootstrapper;
        }
    }
}
