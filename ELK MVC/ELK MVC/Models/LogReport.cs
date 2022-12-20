using Elastic.Clients.Elasticsearch;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Sample_ELK
{
    public partial class LogReport
    {
        [JsonProperty("@timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("level")]
        public Level Level { get; set; }

        [JsonProperty("messageTemplate")]
        public Message MessageTemplate { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("exceptions", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionElement[] Exceptions { get; set; }
    }

    public partial class ExceptionElement
    {
        [JsonProperty("Depth")]
        public long Depth { get; set; }

        [JsonProperty("ClassName")]
        public string ClassName { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("StackTraceString")]
        public string StackTraceString { get; set; }

        [JsonProperty("RemoteStackTraceString")]
        public object RemoteStackTraceString { get; set; }

        [JsonProperty("RemoteStackIndex")]
        public long RemoteStackIndex { get; set; }

        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("HelpURL")]
        public object HelpUrl { get; set; }
    }

    public partial class Fields
    {
        [JsonProperty("SourceContext")]
        public string SourceContext { get; set; }

        [JsonProperty("ActionId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ActionId { get; set; }

        [JsonProperty("ActionName", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionName { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("RequestPath")]
        public RequestPath RequestPath { get; set; }

        [JsonProperty("ConnectionId")]
        public string ConnectionId { get; set; }

        [JsonProperty("ApplicationName")]
        public ApplicationName ApplicationName { get; set; }

        [JsonProperty("Environment")]
        public Environment Environment { get; set; }

        [JsonProperty("EventId", NullValueHandling = NullValueHandling.Ignore)]
        public EventId EventId { get; set; }

        [JsonProperty("ExceptionDetail", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionDetail ExceptionDetail { get; set; }
    }

    public partial class EventId
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public Name Name { get; set; }
    }

    public partial class ExceptionDetail
    {
        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("InnerException", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionDetailInnerException InnerException { get; set; }

        [JsonProperty("SeenExceptions", NullValueHandling = NullValueHandling.Ignore)]
        public object[] SeenExceptions { get; set; }

        [JsonProperty("AuditTrail", NullValueHandling = NullValueHandling.Ignore)]
        public AuditTrail[] AuditTrail { get; set; }

        [JsonProperty("FailureReason", NullValueHandling = NullValueHandling.Ignore)]
        public string FailureReason { get; set; }

        [JsonProperty("Request", NullValueHandling = NullValueHandling.Ignore)]
        public Request Request { get; set; }

        [JsonProperty("ApiCallDetails")]
        public object ApiCallDetails { get; set; }

        [JsonProperty("DebugInformation", NullValueHandling = NullValueHandling.Ignore)]
        public string DebugInformation { get; set; }

        [JsonProperty("ParamName")]
        public object ParamName { get; set; }

        [JsonProperty("LineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineNumber { get; set; }

        [JsonProperty("LinePosition", NullValueHandling = NullValueHandling.Ignore)]
        public long? LinePosition { get; set; }

        [JsonProperty("Path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("Response")]
        public object Response { get; set; }
    }

    public partial class AuditTrail
    {
        [JsonProperty("Event")]
        public string Event { get; set; }

        [JsonProperty("Node")]
        public AuditTrailNode Node { get; set; }

        [JsonProperty("PathAndQuery", NullValueHandling = NullValueHandling.Ignore)]
        public string PathAndQuery { get; set; }

        [JsonProperty("Ended")]
        public DateTimeOffset Ended { get; set; }

        [JsonProperty("Started")]
        public DateTimeOffset Started { get; set; }

        [JsonProperty("Exception")]
        public ExceptionClass Exception { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }
    }

    public partial class ExceptionClass
    {
        [JsonProperty("LineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineNumber { get; set; }

        [JsonProperty("BytePositionInLine", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytePositionInLine { get; set; }

        [JsonProperty("Path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("TargetSite")]
        public string TargetSite { get; set; }

        [JsonProperty("Data")]
        public MemoryStreamFactory Data { get; set; }

        [JsonProperty("InnerException")]
        public ExceptionInnerException InnerException { get; set; }

        [JsonProperty("HelpLink")]
        public object HelpLink { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("StackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty("Offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("ActualChar", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualChar { get; set; }
    }

    public partial class MemoryStreamFactory
    {
    }

    public partial class ExceptionInnerException
    {
        [JsonProperty("TargetSite")]
        public string TargetSite { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Data")]
        public MemoryStreamFactory Data { get; set; }

        [JsonProperty("InnerException")]
        public object InnerException { get; set; }

        [JsonProperty("HelpLink")]
        public object HelpLink { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("StackTrace")]
        public string StackTrace { get; set; }
    }

    public partial class AuditTrailNode
    {
        [JsonProperty("Features", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Features { get; set; }

        [JsonProperty("Settings", NullValueHandling = NullValueHandling.Ignore)]
        public MemoryStreamFactory Settings { get; set; }

        [JsonProperty("Id")]
        public object NodeId { get; set; }

        [JsonProperty("Name")]
        public object Name { get; set; }

        [JsonProperty("Uri", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Uri { get; set; }

        [JsonProperty("IsAlive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAlive { get; set; }

        [JsonProperty("DeadUntil", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DeadUntil { get; set; }

        [JsonProperty("FailedAttempts", NullValueHandling = NullValueHandling.Ignore)]
        public long? FailedAttempts { get; set; }

        [JsonProperty("IsResurrected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsResurrected { get; set; }

        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }

        [JsonProperty("ClientNode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClientNode { get; set; }

        [JsonProperty("HoldsData", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HoldsData { get; set; }

        [JsonProperty("HttpEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HttpEnabled { get; set; }

        [JsonProperty("IngestEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IngestEnabled { get; set; }

        [JsonProperty("MasterEligible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MasterEligible { get; set; }

        [JsonProperty("MasterOnlyNode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MasterOnlyNode { get; set; }

        [JsonProperty("$ref", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Ref { get; set; }
    }

    public partial class ExceptionDetailInnerException
    {
        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("InnerException", NullValueHandling = NullValueHandling.Ignore)]
        public InnerExceptionInnerException InnerException { get; set; }

        [JsonProperty("LineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineNumber { get; set; }

        [JsonProperty("BytePositionInLine", NullValueHandling = NullValueHandling.Ignore)]
        public long? BytePositionInLine { get; set; }

        [JsonProperty("Path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("ActualChar", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualChar { get; set; }
    }

    public partial class InnerExceptionInnerException
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("HResult")]
        public long HResult { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("Accept")]
        public string Accept { get; set; }

        [JsonProperty("AllowedStatusCodes")]
        public object[] AllowedStatusCodes { get; set; }

        [JsonProperty("AuthenticationHeader")]
        public object AuthenticationHeader { get; set; }

        [JsonProperty("ClientCertificates")]
        public object ClientCertificates { get; set; }

        [JsonProperty("ConnectionSettings")]
        public ConnectionSettings ConnectionSettings { get; set; }

        [JsonProperty("CustomResponseBuilder")]
        public object CustomResponseBuilder { get; set; }

        [JsonProperty("DisableAutomaticProxyDetection")]
        public bool DisableAutomaticProxyDetection { get; set; }

        [JsonProperty("ResponseHeadersToParse", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ResponseHeadersToParse { get; set; }

        [JsonProperty("ParseAllHeaders", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ParseAllHeaders { get; set; }

        [JsonProperty("Headers")]
        public object[] Headers { get; set; }

        [JsonProperty("HttpCompression")]
        public bool HttpCompression { get; set; }

        [JsonProperty("KeepAliveInterval")]
        public long KeepAliveInterval { get; set; }

        [JsonProperty("KeepAliveTime")]
        public long KeepAliveTime { get; set; }

        [JsonProperty("MadeItToResponse")]
        public bool MadeItToResponse { get; set; }

        [JsonProperty("MemoryStreamFactory")]
        public MemoryStreamFactory MemoryStreamFactory { get; set; }

        [JsonProperty("Method")]
        public string Method { get; set; }

        [JsonProperty("Node")]
        public RequestNode Node { get; set; }

        [JsonProperty("OnFailureAuditEvent")]
        public string OnFailureAuditEvent { get; set; }

        [JsonProperty("OnFailurePipelineFailure")]
        public string OnFailurePipelineFailure { get; set; }

        [JsonProperty("PathAndQuery")]
        public string PathAndQuery { get; set; }

        [JsonProperty("PingTimeout")]
        public DateTimeOffset PingTimeout { get; set; }

        [JsonProperty("Pipelined")]
        public bool Pipelined { get; set; }

        [JsonProperty("PostData")]
        public PostData PostData { get; set; }

        [JsonProperty("ProxyAddress")]
        public object ProxyAddress { get; set; }

        [JsonProperty("ProxyPassword")]
        public object ProxyPassword { get; set; }

        [JsonProperty("ProxyUsername")]
        public object ProxyUsername { get; set; }

        [JsonProperty("RequestMimeType")]
        public string RequestMimeType { get; set; }

        [JsonProperty("RequestTimeout")]
        public DateTimeOffset RequestTimeout { get; set; }

        [JsonProperty("RunAs")]
        public object RunAs { get; set; }

        [JsonProperty("SkipDeserializationForStatusCodes")]
        public object[] SkipDeserializationForStatusCodes { get; set; }

        [JsonProperty("ThrowExceptions")]
        public bool ThrowExceptions { get; set; }

        [JsonProperty("UserAgent")]
        public UserAgent UserAgent { get; set; }

        [JsonProperty("TransferEncodingChunked")]
        public bool TransferEncodingChunked { get; set; }

        [JsonProperty("TcpStats")]
        public bool TcpStats { get; set; }

        [JsonProperty("ThreadPoolStats")]
        public bool ThreadPoolStats { get; set; }

        [JsonProperty("Uri")]
        public Uri Uri { get; set; }

        [JsonProperty("DnsRefreshTimeout")]
        public DateTimeOffset DnsRefreshTimeout { get; set; }

        [JsonProperty("MetaHeaderProvider")]
        public MetaHeaderProvider MetaHeaderProvider { get; set; }

        [JsonProperty("RequestMetaData")]
        public MemoryStreamFactory RequestMetaData { get; set; }

        [JsonProperty("IsAsync")]
        public bool IsAsync { get; set; }

        [JsonProperty("ApiKeyAuthenticationCredentials")]
        public object ApiKeyAuthenticationCredentials { get; set; }

        [JsonProperty("BasicAuthorizationCredentials")]
        public object BasicAuthorizationCredentials { get; set; }

        [JsonProperty("JsonContentMimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string JsonContentMimeType { get; set; }
    }

    public partial class ConnectionSettings
    {
        [JsonProperty("SourceSerializer", NullValueHandling = NullValueHandling.Ignore)]
        public SourceSerializer SourceSerializer { get; set; }
    }

    public partial class SourceSerializer
    {
        [JsonProperty("Options")]
        public Options Options { get; set; }
    }

    public partial class Options
    {
        [JsonProperty("Converters")]
        public ConverterElement[] Converters { get; set; }

        [JsonProperty("AllowTrailingCommas")]
        public bool AllowTrailingCommas { get; set; }

        [JsonProperty("DefaultBufferSize")]
        public long DefaultBufferSize { get; set; }

        [JsonProperty("Encoder")]
        public object Encoder { get; set; }

        [JsonProperty("DictionaryKeyPolicy")]
        public object DictionaryKeyPolicy { get; set; }

        [JsonProperty("IgnoreNullValues")]
        public bool IgnoreNullValues { get; set; }

        [JsonProperty("DefaultIgnoreCondition")]
        public string DefaultIgnoreCondition { get; set; }

        [JsonProperty("NumberHandling")]
        public string NumberHandling { get; set; }

        [JsonProperty("IgnoreReadOnlyProperties")]
        public bool IgnoreReadOnlyProperties { get; set; }

        [JsonProperty("IgnoreReadOnlyFields")]
        public bool IgnoreReadOnlyFields { get; set; }

        [JsonProperty("IncludeFields")]
        public bool IncludeFields { get; set; }

        [JsonProperty("MaxDepth")]
        public long MaxDepth { get; set; }

        [JsonProperty("PropertyNamingPolicy")]
        public MemoryStreamFactory PropertyNamingPolicy { get; set; }

        [JsonProperty("PropertyNameCaseInsensitive")]
        public bool PropertyNameCaseInsensitive { get; set; }

        [JsonProperty("ReadCommentHandling")]
        public string ReadCommentHandling { get; set; }

        [JsonProperty("UnknownTypeHandling")]
        public string UnknownTypeHandling { get; set; }

        [JsonProperty("WriteIndented")]
        public bool WriteIndented { get; set; }

        [JsonProperty("ReferenceHandler")]
        public object ReferenceHandler { get; set; }
    }

    public partial class ConverterElement
    {
        [JsonProperty("HandleNull", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HandleNull { get; set; }
    }

    public partial class MetaHeaderProvider
    {
        [JsonProperty("HeaderName")]
        public string HeaderName { get; set; }
    }

    public partial class RequestNode
    {
        [JsonProperty("$ref")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Ref { get; set; }
    }

    public partial class PostData
    {
        [JsonProperty("DisableDirectStreaming")]
        public bool DisableDirectStreaming { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("WrittenBytes")]
        public object WrittenBytes { get; set; }
    }

    public enum ApplicationName { SampleElk };

    public enum Environment { Development };

    public enum Name { UnhandledException };

    public enum RequestPath { SwaggerV1SwaggerJson, WeatherForecastGet, WeatherForecastSetLog };

    public enum Level { Error };

    public enum Message { AnUnhandledExceptionHasOccurredWhileExecutingTheRequest, Cool };

    public partial struct UserAgent
    {
        public MemoryStreamFactory MemoryStreamFactory;
        public string String;

        public static implicit operator UserAgent(MemoryStreamFactory MemoryStreamFactory) => new UserAgent { MemoryStreamFactory = MemoryStreamFactory };
        public static implicit operator UserAgent(string String) => new UserAgent { String = String };
    }

    public partial class LogReport
    {
        public static LogReport[] FromJson(string json) => JsonConvert.DeserializeObject<LogReport[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this LogReport[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ApplicationNameConverter.Singleton,
                EnvironmentConverter.Singleton,
                NameConverter.Singleton,
                UserAgentConverter.Singleton,
                RequestPathConverter.Singleton,
                LevelConverter.Singleton,
                MessageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ApplicationNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ApplicationName) || t == typeof(ApplicationName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Sample ELK")
            {
                return ApplicationName.SampleElk;
            }
            throw new System.Exception("Cannot unmarshal type ApplicationName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ApplicationName)untypedValue;
            if (value == ApplicationName.SampleElk)
            {
                serializer.Serialize(writer, "Sample ELK");
                return;
            }
            throw new System.Exception("Cannot marshal type ApplicationName");
        }

        public static readonly ApplicationNameConverter Singleton = new ApplicationNameConverter();
    }

    internal class EnvironmentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Environment) || t == typeof(Environment?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Development")
            {
                return Environment.Development;
            }
            throw new System.Exception("Cannot unmarshal type Environment");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Environment)untypedValue;
            if (value == Environment.Development)
            {
                serializer.Serialize(writer, "Development");
                return;
            }
            throw new System.Exception("Cannot marshal type Environment");
        }

        public static readonly EnvironmentConverter Singleton = new EnvironmentConverter();
    }

    internal class NameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Name) || t == typeof(Name?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "UnhandledException")
            {
                return Name.UnhandledException;
            }
            throw new System.Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Name)untypedValue;
            if (value == Name.UnhandledException)
            {
                serializer.Serialize(writer, "UnhandledException");
                return;
            }
            throw new System.Exception("Cannot marshal type Name");
        }

        public static readonly NameConverter Singleton = new NameConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new System.Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class UserAgentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(UserAgent) || t == typeof(UserAgent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new UserAgent { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<MemoryStreamFactory>(reader);
                    return new UserAgent { MemoryStreamFactory = objectValue };
            }
            throw new System.Exception("Cannot unmarshal type UserAgent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (UserAgent)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.MemoryStreamFactory != null)
            {
                serializer.Serialize(writer, value.MemoryStreamFactory);
                return;
            }
            throw new System.Exception("Cannot marshal type UserAgent");
        }

        public static readonly UserAgentConverter Singleton = new UserAgentConverter();
    }

    internal class RequestPathConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RequestPath) || t == typeof(RequestPath?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "/WeatherForecast/Get":
                    return RequestPath.WeatherForecastGet;
                case "/WeatherForecast/SetLog":
                    return RequestPath.WeatherForecastSetLog;
                case "/swagger/v1/swagger.json":
                    return RequestPath.SwaggerV1SwaggerJson;
            }
            throw new System.Exception("Cannot unmarshal type RequestPath");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RequestPath)untypedValue;
            switch (value)
            {
                case RequestPath.WeatherForecastGet:
                    serializer.Serialize(writer, "/WeatherForecast/Get");
                    return;
                case RequestPath.WeatherForecastSetLog:
                    serializer.Serialize(writer, "/WeatherForecast/SetLog");
                    return;
                case RequestPath.SwaggerV1SwaggerJson:
                    serializer.Serialize(writer, "/swagger/v1/swagger.json");
                    return;
            }
            throw new System.Exception("Cannot marshal type RequestPath");
        }

        public static readonly RequestPathConverter Singleton = new RequestPathConverter();
    }

    internal class LevelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Level) || t == typeof(Level?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Error")
            {
                return Level.Error;
            }
            throw new System.Exception("Cannot unmarshal type Level");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Level)untypedValue;
            if (value == Level.Error)
            {
                serializer.Serialize(writer, "Error");
                return;
            }
            throw new System.Exception("Cannot marshal type Level");
        }

        public static readonly LevelConverter Singleton = new LevelConverter();
    }

    internal class MessageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Message) || t == typeof(Message?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "An unhandled exception has occurred while executing the request.":
                    return Message.AnUnhandledExceptionHasOccurredWhileExecutingTheRequest;
                case "Cool":
                    return Message.Cool;
            }
            throw new System.Exception("Cannot unmarshal type Message");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Message)untypedValue;
            switch (value)
            {
                case Message.AnUnhandledExceptionHasOccurredWhileExecutingTheRequest:
                    serializer.Serialize(writer, "An unhandled exception has occurred while executing the request.");
                    return;
                case Message.Cool:
                    serializer.Serialize(writer, "Cool");
                    return;
            }
            throw new System.Exception("Cannot marshal type Message");
        }

        public static readonly MessageConverter Singleton = new MessageConverter();
    }
}
