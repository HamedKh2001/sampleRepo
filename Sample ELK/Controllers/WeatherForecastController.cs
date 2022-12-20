using ELK_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace Sample_ELK.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IElasticClient _client;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _client = new ElasticClient(new Uri("http://localhost:9200"));
            _logger = logger;
        }




        public class Tweet
        {
            public int Id { get; set; }
            public string User { get; set; }
            public DateTime PostDate { get; set; }
            public string Message { get; set; }
        }

        [HttpGet]
        public async void Create()
        {
            var response1 = await _client.GetAsync<Tweet>(1, idx => idx.Index("my-tweet-index"));
            var tweet1 = response1.Source;



            var tweet = new Tweet
            {
                Id = 2,
                User = "stevejgordon",
                PostDate = new DateTime(2009, 11, 15),
                Message = "Trying out the client, so far so good?"
            };

            var response = await _client.IndexAsync(tweet, request => request.Index("my-tweet-index"));

            if (response.IsValid)
            {
                Console.WriteLine($"Index document with ID {response.Id} succeeded.");
            }


        }


        [HttpGet]
        public IEnumerable<WeatherForecast> SetLog()
        {
            _logger.LogInformation(Summaries[0].ToString());
            _logger.LogCritical(Summaries[1].ToString());
            _logger.LogWarning(Summaries[2].ToString());
            _logger.LogError(Summaries[3].ToString());
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public async Task<LogReport> GetId(int id)
        {
            var response = await _client.GetAsync<LogReport>(id, idx => idx.Index("mywebapilog-logs-2022.12.18"));
            var src = response.Source;
            return src;
        }

        [HttpGet]
        public async Task<List<LogReport>> Get()
        {
            //    var response = await _client.SearchAsync<Root>(s => s
            //        .Index("mywebapilog-logs-2022.12.18")
            //        .Query(q => q.QueryString(qs => qs.Query('*' + "Error" + '*')))
            //    );
            var response = await _client.SearchAsync<Dictionary<string,object>>(s => s
                .Index("mywebapilog-logs-*")
                .From(0)
                .Size(200)
                .Query(q => q.QueryString(qs => qs.Query("level : Error"))));

            if (response.IsValid)
            {
                Console.WriteLine(response.Documents.First().Keys.First());
                Console.WriteLine(response.Documents.First().Values.First());
                var x = JsonConvert.SerializeObject(response.Documents.First());
                var res = response.Documents.Select(s => JsonConvert.DeserializeObject<LogReport>(x)).ToList();
                return res;
            }
            return null;
        }

        //private static T GetObject<T>(this Dictionary<string, object> dict)
        //{
        //    return (T)GetObject(dict, typeof(T));
        //}
    }
}