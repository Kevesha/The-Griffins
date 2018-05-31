using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.Text;

namespace TaskExecutor.Nancy
{
    public class NancyBootstrapper: DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.OnError += (context, exception) =>
            {
                if (exception is BadRequestException)
                    return new Response()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ContentType = "powerShellScript/html ",
                        Contents = (stream) =>
                        {
                            var errorMessage = Encoding.UTF8.GetBytes(exception.Message);
                            stream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    };
                return HttpStatusCode.BadRequest;
            };
        }
    }
}
