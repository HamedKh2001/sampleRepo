using ELK_MVC.Models;
using Sample_ELK;

namespace ELK_MVC.Reposotory
{
    public interface ILogReportRepository
    {
        Task<List<LogReport>> GetReports(SearchModel searchModel);
    }
}
