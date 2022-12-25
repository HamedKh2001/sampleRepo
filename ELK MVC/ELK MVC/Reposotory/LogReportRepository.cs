using ELK_MVC.Models;
using Nest;
using Newtonsoft.Json;
using Sample_ELK;
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
            var From = searchModel.From.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var To = searchModel.To.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var response = await _client.SearchAsync<object>(s => s
               .Index($"{BaseIndex}")
               .From(searchModel.Skip)
               .Size(searchModel.Size)
               .Query(q => q.Bool(b => b
                         .Filter(f => ProvideDateRangeQuery(f, searchModel.From, searchModel.To) &&
                             q.QueryString(q => q.Query(ProvideLogLevelQuery(searchModel.LogLevels).ToString())) &&
                             q.QueryString(q => q.Query(ProvideApplicationNameQuery(searchModel.AppicationName).ToString())) &&
                             q.QueryString(q=>q.Query(ProvideMessageQuery(searchModel.Message).ToString())) &&
                             q.QueryString(q => q.Query(ProvideUserNameQuery(searchModel.UserName).ToString())) && 
                             q.QueryString(q => q.Query(ProvideRemoteIpAddressQuery(searchModel.RemoteIpAddress).ToString()))
                                 ))));

            if (response.IsValid)
            {
                var jsonList = JsonConvert.SerializeObject(response.Documents);
                var resault = JsonConvert.DeserializeObject<List<LogReport>>(jsonList);
                return resault;
            }
            return null;
        }

        #region Helper
        private StringBuilder ProvideLogLevelQuery(IEnumerable<Microsoft.Extensions.Logging.LogLevel> logLevels)
        {
            bool flag = false;
            var queryString = new StringBuilder();
            if (logLevels.Any())
            {
                queryString.Append("level : ");
                foreach (var lvl in logLevels)
                {
                    if (flag)
                        queryString.Append($" or ");

                    queryString.Append($"\"{Enum.GetName(lvl)}\"");
                    flag = true;
                }
            }
            return queryString;
        }
        private StringBuilder ProvideApplicationNameQuery(string applicationName)
        {
            var queryString = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(applicationName))
                queryString.Append($"fields.ApplicationName : \"{applicationName}\"");
            else
                queryString.Append("");

            return queryString;
        }
        private QueryContainer ProvideDateRangeQuery(QueryContainerDescriptor<object> queryContainerDescriptor, DateTime from, DateTime to)
        {
            return queryContainerDescriptor.DateRange(dr => dr
                          .Field("@timestamp")
                              .GreaterThanOrEquals(from)
                              .LessThanOrEquals(to));
        }
        private StringBuilder ProvideMessageQuery(string message)
        {
            var queryString = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(message))
                queryString.Append($"message : {message}");
            else
                queryString.Append("");

            return queryString;
        }
        private StringBuilder ProvideUserNameQuery(string userName)
        {
            var queryString = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(userName))
                queryString.Append($"fields.UserName : \"{userName}\"");
            else
                queryString.Append("");

            return queryString;
        }
        private StringBuilder ProvideRemoteIpAddressQuery(string remoteIpAddress)
        {
            var queryString = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(remoteIpAddress))
                queryString.Append($"fields.RemoteIpAddress : \"{remoteIpAddress}\"");
            else
                queryString.Append("");

            return queryString;
        }
        #endregion
    }
}
