using ELK_MVC.Models;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sample_ELK;
using System;
using System.Globalization;

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
            string index = BaseIndex;
            //string query = "level : ";
            //var query = new StringBuilder("level : ");
            //if (searchModel.level.Count > 0)
            //    foreach (var lvl in searchModel.level)
            //    {
            //        if (!string.IsNullOrWhiteSpace(lvl.GetStringValue()))
            //        {
            //            query.Append($"{lvl.GetStringValue()}");
            //            query.Append($" or ");
            //        }
            //    }
            //var q = query.ToString();
            //if (searchModel.timestamp != null)
            //{
            //    index = index + searchModel.timestamp.Year + "." + searchModel.timestamp.Month + "." + searchModel.timestamp.Day;
            //}
            var From = searchModel.From.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var To = searchModel.To.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
            var response = await _client.SearchAsync<object>(s => s
               .Index($"{index}")
               .From(searchModel.Skip)
               .Size(searchModel.Size)
               .Query(q => q.Bool(b => b
                         .Filter(f => f.DateRange(dr => dr
                         .Field("@timestamp")
                             .GreaterThanOrEquals(From)
                             .LessThanOrEquals(To)) && f.QueryString(q => q.Query($"level : {searchModel.level}"))))));

            if (response.IsValid)
            {
                var x = JsonConvert.SerializeObject(response.Documents);
                var res = JsonConvert.DeserializeObject<List<LogReport>>(x, Sample_ELK.Converter.Settings);
                return res;
            }

            return null;
        }
    }










 
}
