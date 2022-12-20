using ELK_MVC.Reposotory;
using Nest;

namespace ELK_MVC
{
    public static class LogReporter
    {
        public static IServiceCollection AddLogReporter(this IServiceCollection services, Uri connectionString)
        {
            var client = new ElasticClient(connectionString);
            services.AddSingleton<IElasticClient>(client);
            services.AddScoped<ILogReportRepository, LogReportRepository>();
            return services;
        }
    }
}

public class LogReportConfig
{
    public string Index { get; set; }
    public string ConnectionString { get; set; }
}
