using Sample_ELK;

namespace ELK_MVC.Models.ViewModel
{
    public class ResponseVm
    {
        public List<LogReport> Reports { get; set; } = new();
        public SearchModel SearchModel { get; set; }
    }
}
