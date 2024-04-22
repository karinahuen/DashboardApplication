using DashboardApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace DashboardApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DashboardViewModel dashboardchModel = new DashboardViewModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dashboardDataList = dashboardchModel.GetDashboardDetail()
                                    .GroupBy(d => d.TenantName)
                                    .Select(s => new
                                    {
                                        TenantName = s.First().TenantName,
                                        UnitRent = s.First().UnitRent,
                                        ColorCode = s.First().ColorCode,
                                        TotalIncome = s.Sum(v => v.TotalIncome),
                                        Date = s.First().IncomeMonthDate,
                                        AreaSqft = s.First().AreaSqft,
                                        ProductMinPriceValue = s.Min(v => v.ProductMinPriceValue),
                                        ProductMaxPriceValue = s.Max(v => v.ProductMaxPriceValue),
                                        TotalSalesQuantity = s.Sum(v => v.TotalSalesQuantity),
                                    });

            List<DashboardViewModel> tenantsList = new List<DashboardViewModel>();
            double totalIncomeAnnual = 0;
            int totalSales = 0;
            foreach(var dashData in dashboardDataList)
            {
                tenantsList.Add(new DashboardViewModel { TenantName = dashData.TenantName, IncomeMonthDate = dashData.Date, UnitRent = dashData.UnitRent, ColorCode = dashData.ColorCode, TotalIncome = dashData.TotalIncome,
                AreaSqft = dashData.AreaSqft, ProductMinPriceValue = dashData.ProductMinPriceValue, ProductMaxPriceValue = dashData.ProductMaxPriceValue, TotalSalesQuantity = dashData.TotalSalesQuantity
                });

                totalIncomeAnnual += dashData.TotalIncome;
                totalSales += dashData.TotalSalesQuantity;
            }
            ViewBag.TenantDetail = tenantsList;
            //(Current Year - Last Year) / Last Year
            double salesRate = (totalSales - 5501);
            salesRate /= 5501;
            ViewBag.TotalSalesRate = salesRate*100;
            ViewBag.TotalSales = totalSales;
            //(Current Year - Last Year) / Last Year
            ViewData["IncomeRate"] = ((totalIncomeAnnual - 100504880) / 100504880)*100;
            ViewData["TotlaIncome"] = (int)(totalIncomeAnnual / 1000000);
            return View();
        }



        public IActionResult Privacy()
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