using DashboardApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace DashboardApplication.Controllers
{
    public class DetailController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime currntDateTime = DateTime.Now;
            currntDateTime = currntDateTime.AddMonths(-1);
            String currentDateString = "2023-1-1";
            currentDateString = currntDateTime.Year.ToString() + "-" + currntDateTime.Month.ToString() + "-1";
            List<DashboardViewModel> tenantList = new List<DashboardViewModel>
            {
                new DashboardViewModel { TenantName = "Shop 1", Date = currentDateString, UnitRent = 30, ColorCode = "#FF5733", TotalIncome = 5034000, AreaSqft = 212.23, ProductMinPriceValue = 30, ProductMaxPriceValue = 324, TotalSellQuantity = 360 },
                new DashboardViewModel { TenantName = "Shop 2", Date = currentDateString, UnitRent = 80, ColorCode = "#196F3D", TotalIncome = 8793351, AreaSqft = 112.01, ProductMinPriceValue = 120, ProductMaxPriceValue = 672, TotalSellQuantity = 474 },
                new DashboardViewModel { TenantName = "Shop 3", Date = currentDateString, UnitRent = 50, ColorCode = "#34495E", TotalIncome = 4567135, AreaSqft = 321, ProductMinPriceValue = 25, ProductMaxPriceValue = 263, TotalSellQuantity = 309 },
                new DashboardViewModel { TenantName = "Shop 4", Date = currentDateString, UnitRent = 40, ColorCode = "#f0c0c0", TotalIncome = 3583120, AreaSqft = 178.3, ProductMinPriceValue = 15, ProductMaxPriceValue = 193, TotalSellQuantity = 290 },
                new DashboardViewModel { TenantName = "Shop 5", Date = currentDateString, UnitRent = 20, ColorCode = "#417c3a", TotalIncome = 6392000, AreaSqft = 267.57, ProductMinPriceValue = 63, ProductMaxPriceValue = 442, TotalSellQuantity = 386 }
            };
            ViewBag.TenantDetail = tenantList;
            ViewData["Rate"] = 30;
            ViewBag.ViewValue = 2350000/1000000;
            ViewData["IncomeRate"] = 23.4;
            ViewData["TotlaIncome"] = 12350543 / 1000000;
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}