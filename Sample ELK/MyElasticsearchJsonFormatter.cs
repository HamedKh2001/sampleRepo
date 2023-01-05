using Serilog.Formatting.Elasticsearch;

namespace Sample_ELK
{
    public class MyElasticsearchJsonFormatter: ElasticsearchJsonFormatter
    {
        private const string MyTimestampPropertyName = "timestamp";
        protected override void WriteTimestamp(DateTimeOffset timestamp, ref string delim, TextWriter output)
        {
            WriteJsonProperty(MyTimestampPropertyName, timestamp, ref delim, output);
        }
    }
}
