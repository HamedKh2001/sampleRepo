using ELK_MVC.Models;
using Nest;
using Newtonsoft.Json;
using Sample_ELK;
using System;
using System.Globalization;
using System.Text;

namespace ELK_MVC.Reposotory
{
    public class LogReportRepository : ILogReportRepository
    {
        private readonly IElasticClient _client;
        private readonly string BaseIndex;

        public LogReportRepository(IElasticClient elasticClient, IConfiguration configuration)
        {
            _client = elasticClient;
            BaseIndex = configuration.GetValue<string>("ElasticConfiguration:Index");
        }
        public async Task<List<LogReport>> GetReports(SearchModel searchModel)
        {
            var query = new StringBuilder();
            query.Append(QueryLevel(searchModel.LogLevels));
            List<Func<QueryContainerDescriptor<object>, QueryContainer>> queries = new();
            var From = searchModel.From.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var To = searchModel.To.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var response = await _client.SearchAsync<object>(s => s
               .Index($"{BaseIndex}")
               .From(searchModel.Skip)
               .Size(searchModel.Size)
               .Query(q => q.Bool(b => b
                         .Filter(f => f.DateRange(dr => dr
                         .Field("@timestamp")
                             .GreaterThanOrEquals(From)
                             .LessThanOrEquals(To)) && q.QueryString(q=>q.Query(query.ToString()))))));

            if (response.IsValid)
            {
                var jsonList = JsonConvert.SerializeObject(response.Documents);
                var resault = JsonConvert.DeserializeObject<List<LogReport>>(jsonList);
                return resault;
            }
            return null;
        }
        private StringBuilder QueryLevel(IEnumerable<Microsoft.Extensions.Logging.LogLevel> logLevels)
        {
            //string query = "level : ";
            bool flag = false;
            var queryString = new StringBuilder("level : ");
            if (logLevels.Any())
                foreach (var lvl in logLevels)
                {
                    if (flag)
                        queryString.Append($" or ");

                    queryString.Append($"{Enum.GetName(lvl)}");
                    flag = true;
                }
            return queryString;
        }
    }
}
