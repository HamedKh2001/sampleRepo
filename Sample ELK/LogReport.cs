using Elastic.Clients.Elasticsearch;
using Newtonsoft.Json;

namespace ELK_MVC.Models
{
    public class EventId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Exception
    {
        public int Depth { get; set; }
        public string ClassName { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTraceString { get; set; }
        public object RemoteStackTraceString { get; set; }
        public int RemoteStackIndex { get; set; }
        public int HResult { get; set; }
        public object HelpURL { get; set; }
    }

    public class ExceptionDetail
    {
        public int HResult { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
    }

    public class Fields
    {
        public string SourceContext { get; set; }
        public string ActionId { get; set; }
        public string ActionName { get; set; }
        public string RequestId { get; set; }
        public string RequestPath { get; set; }
        public string ConnectionId { get; set; }
        public string ApplicationName { get; set; }
        public string Environment { get; set; }
    }

    public class LogReport
    {
        [JsonProperty("@timestamp")]
        public DateTimeOffset timestamp { get; set; }
        public string level { get; set; }
        public string messageTemplate { get; set; }
        public string message { get; set; }
        public Fields fields { get; set; }
    }
}
