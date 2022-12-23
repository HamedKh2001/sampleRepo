namespace ELK_MVC.Models
{
    public class SearchModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string AppicationName { get; set; }
        public List<LogLevel> LogLevels { get; set; } = new();
            //public LogLevel LogLevel { get; set; } = new();
        public int Size { get; set; }
        public int Skip { get; set; }

    }
}
