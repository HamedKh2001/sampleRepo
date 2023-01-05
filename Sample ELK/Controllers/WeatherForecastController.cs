using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using Newtonsoft.Json;

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

        private readonly Serilog.ILogger _logger;

        public WeatherForecastController(Serilog.ILogger logger)
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
            public virtual ICollection<User> Users { get; set; }
        }

        [HttpGet]
        public async void Create()
        {
            var tweet2 = new Tweet()
            {
                Id = 1,
                Message = "Trying out the client, so far so good?",
                PostDate = DateTime.Now,
                User = "User 1",

            };
            var serializedObj = JsonConvert.SerializeObject(tweet2, Formatting.Indented);
            Console.WriteLine(serializedObj);
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

            try
            {
                var Zero = 0;
                var x = 5 / Zero;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
            }
            _logger.Information(Summaries[3].ToString());
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportExpDate { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string FirstNameEn { get; set; }
        public string LastName { get; set; }
        public string LastNameEn { get; set; }
        public string Mobile { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<string> Groups { get; set; }
    }
}