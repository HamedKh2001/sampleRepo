using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using Serilog.Exceptions;
using Serilog.Context;

namespace Sample_ELK
{
    public static class LoggingConfiguration
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
        (context, configuration) =>
        {
            #region Enriching Logger Context
            var env = context.HostingEnvironment;
            configuration.Enrich.FromLogContext()
        .Enrich.WithProperty("ApplicationName", env.ApplicationName)
        .Enrich.WithProperty("Environment", env.EnvironmentName)
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails();
            #endregion
            if (env.IsDevelopment())
            {
                configuration.WriteTo.Console().MinimumLevel.Information();
            }


            #region ElasticSearch Configuration.
            var elasticUrl = context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
            if (!string.IsNullOrEmpty(elasticUrl))
            {
                configuration.WriteTo.Elasticsearch(
            //new ElasticsearchSinkOptions(new List<Uri>() { new Uri("http://localhost:9200"), new Uri("http://localhost:9202") })
            new ElasticsearchSinkOptions(new List<Uri>() { new Uri(elasticUrl) })
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                IndexFormat = "mywebapilog-logs-{0:yyyy.MM.dd}",
                MinimumLogEventLevel = LogEventLevel.Debug,
            });
            }
            #endregion
        };
    }
    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;

        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("UserName", context.User.Identity.Name);
            LogContext.PushProperty("RemoteIpAddress", context.Connection.RemoteIpAddress);
            LogContext.PushProperty("RemotePort", context.Connection.RemotePort);

            return next(context);
        }
    }
}
