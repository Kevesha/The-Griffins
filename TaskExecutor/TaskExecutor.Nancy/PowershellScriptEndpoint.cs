using Nancy;
using Nancy.ModelBinding;
using TaskExecutor.Nancy.Models;
using TaskExecutorBoundry;

namespace TaskExecutor.Nancy
{
    public class PowershellScriptEndpoint : NancyModule
    {
        public PowershellScriptEndpoint(IPowershellScript PowershellScript)
        {
            Post["/script"] = x =>
            {
                var scriptContent = this.Bind<ScriptModel>();

                if (scriptContent.powerShellScript != "")
                {
                    var command = scriptContent.powerShellScript;

                    scriptContent.powerShellScript = PowershellScript.ExecuteScript(command);
                    if (scriptContent.powerShellScript.Contains("is not recognized"))
                    {
                        return Negotiate.WithStatusCode(HttpStatusCode.BadRequest)
                            .WithModel(scriptContent);
                    }

                    return Negotiate.WithStatusCode(HttpStatusCode.OK)
                        .WithModel(scriptContent);
                }
                
                return Negotiate.WithStatusCode(HttpStatusCode.BadRequest);

            };
        }
    }
}
