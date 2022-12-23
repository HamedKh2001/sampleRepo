using Newtonsoft.Json;

namespace Sample_ELK
{
    public class LogReport
    {
        [JsonProperty("@timestamp")]
        public DateTimeOffset @timestamp { get; set; }
        public string level { get; set; }
        public string messageTemplate { get; set; }
        public string message { get; set; }
        public Exception[] exceptions { get; set; }
        public Fields fields { get; set; }
    }

    public class Fields
    {
        public Eventid EventId { get; set; }
        public string SourceContext { get; set; }
        public string RequestId { get; set; }
        public string RequestPath { get; set; }
        public string ConnectionId { get; set; }
        public string ApplicationName { get; set; }
        public string Environment { get; set; }
        public Exceptiondetail ExceptionDetail { get; set; }
    }

    public class Eventid
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Exceptiondetail
    {
        public string Type { get; set; }
        public int HResult { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
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
}