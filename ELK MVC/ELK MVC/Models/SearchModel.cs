namespace ELK_MVC.Models
{
    public class SearchModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        //public List<LogLevels> level { get; set; } = new();
        public LogLevel level { get; set; } = new();
        public int Size { get; set; }
        public int Skip { get; set; }
    }

    public enum LogLevel
    {
        Debug,
        Information,
        Error,
        Fatal,
    }
}
