using ELK_MVC.Models;
using ELK_MVC.Models.ViewModel;
using ELK_MVC.Reposotory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ELK_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogReportRepository _logReportRepository;

        public HomeController(ILogger<HomeController> logger, ILogReportRepository logReportRepository)
        {
            _logger = logger;
            _logReportRepository = logReportRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetReport()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetReport(ResponseVm responseVm)
        {
            var res = await _logReportRepository.GetReports(responseVm.SearchModel);
            responseVm.Reports.AddRange(res);
            return View(responseVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}