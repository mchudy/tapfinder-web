using System.Web.Http.ExceptionHandling;
using NLog;

namespace TapFinder.Web.Infrastructure
{
    public sealed class NLogExceptionLogger : ExceptionLogger
    {
        private readonly ILogger logger;

        public NLogExceptionLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            logger.Fatal(context.Exception, "Error occured when processing the request {0}. Controller: {1}, Action: {2}",
                context?.Request.RequestUri, context.ExceptionContext?.ControllerContext?.ControllerDescriptor?.ControllerName,
                context.ExceptionContext?.ActionContext?.ActionDescriptor?.ActionName);
        }
    }
}