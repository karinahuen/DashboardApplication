using DashboardApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DashboardApplication.Controllers
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;
        public DetailSearchViewModel detailSearchModel = new DetailSearchViewModel();

        public DetailController(ILogger<DetailController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            detailSearchModel.SearchDetailList = new List<DashboardViewModel>();

            List<DashboardViewModel> tenantList = GetDashboardDetail();
            detailSearchModel.SearchDetailList = tenantList;
            DateTime currentDate = DateTime.Today;
            ViewData["currentDate"] = currentDate.ToString("yyyy-MM-dd");

            return View(detailSearchModel);
        }

        [HttpPost]
        public IActionResult Index(string FilterDateTextBox)
        {

            detailSearchModel.SearchDetailList = new List<DashboardViewModel>();
            List<DashboardViewModel> searchTenantList = GetDashboardDetail();

            //check the date validation in text box
            DateTime temp;
            if (DateTime.TryParse(FilterDateTextBox, out temp))
            {
                temp = DateTime.Parse(FilterDateTextBox);

                IEnumerable<DashboardViewModel> searchDetailQuery =
                from teantDetail in searchTenantList
                where DateTime.Parse(teantDetail.Date) <= temp
                select teantDetail;

                detailSearchModel.SearchDetailList = searchDetailQuery.ToList();
            }
            else if (string.IsNullOrEmpty(FilterDateTextBox))
            {
                detailSearchModel.SearchDetailList = searchTenantList;
            }

            ViewData["currentDate"] = FilterDateTextBox;

            return View(detailSearchModel);
        }

        public List<DashboardViewModel> GetDashboardDetail()
        {

            DateTime currntDateTime = DateTime.Now;
            String currentDateString = "2023-1-1";
            String currentPreviousDateString = "2022-12-31";
            String currentPreviousThreeMonthDateString = "2022-11-1";
            int totalCount = 3;
            for (int i = 0; i < totalCount; i++)
            {
                currntDateTime = currntDateTime.AddMonths(-1);

                if (i == 0)
                    currentDateString = currntDateTime.Year.ToString() + "-" + currntDateTime.Month.ToString() + "-1";
                else if (i == 1)
                    currentPreviousDateString = currntDateTime.Year.ToString() + "-" + currntDateTime.Month.ToString() + "-1";
                else
                    currentPreviousThreeMonthDateString = currntDateTime.Year.ToString() + "-" + currntDateTime.Month.ToString() + "-1";

            }

            List<DashboardViewModel> tenantList = new List<DashboardViewModel>
            {
                new DashboardViewModel { TenantName = "Shop 1", Date = currentDateString, UnitRent = 30, ColorCode = "#FF5733", TotalIncome = 5034000, AreaSqft = 212.23, ProductMinPriceValue = 30, ProductMaxPriceValue = 324, TotalSellQuantity = 360 },
                new DashboardViewModel { TenantName = "Shop 2", Date = currentDateString, UnitRent = 80, ColorCode = "#196F3D", TotalIncome = 8793351, AreaSqft = 112.01, ProductMinPriceValue = 120, ProductMaxPriceValue = 672, TotalSellQuantity = 474 },
                new DashboardViewModel { TenantName = "Shop 3", Date = currentDateString, UnitRent = 50, ColorCode = "#34495E", TotalIncome = 4567135, AreaSqft = 321, ProductMinPriceValue = 25, ProductMaxPriceValue = 263, TotalSellQuantity = 309 },
                new DashboardViewModel { TenantName = "Shop 4", Date = currentDateString, UnitRent = 40, ColorCode = "#f0c0c0", TotalIncome = 3583120, AreaSqft = 178.3, ProductMinPriceValue = 15, ProductMaxPriceValue = 193, TotalSellQuantity = 290 },
                new DashboardViewModel { TenantName = "Shop 5", Date = currentDateString, UnitRent = 20, ColorCode = "#417c3a", TotalIncome = 6392000, AreaSqft = 267.57, ProductMinPriceValue = 63, ProductMaxPriceValue = 442, TotalSellQuantity = 386 },
                new DashboardViewModel { TenantName = "Shop 1", Date = currentPreviousDateString, UnitRent = 10, ColorCode = "#FF5733", TotalIncome = 4803983, AreaSqft = 212.23, ProductMinPriceValue = 30, ProductMaxPriceValue = 654, TotalSellQuantity = 405 },
                new DashboardViewModel { TenantName = "Shop 2", Date = currentPreviousDateString, UnitRent = 50, ColorCode = "#196F3D", TotalIncome = 7837263, AreaSqft = 112.01, ProductMinPriceValue = 110, ProductMaxPriceValue = 532, TotalSellQuantity = 470 },
                new DashboardViewModel { TenantName = "Shop 3", Date = currentPreviousDateString, UnitRent = 20, ColorCode = "#34495E", TotalIncome = 6432903, AreaSqft = 321, ProductMinPriceValue = 34, ProductMaxPriceValue = 352, TotalSellQuantity = 320 },
                new DashboardViewModel { TenantName = "Shop 4", Date = currentPreviousDateString, UnitRent = 50, ColorCode = "#f0c0c0", TotalIncome = 5323412, AreaSqft = 178.3, ProductMinPriceValue = 10, ProductMaxPriceValue = 234, TotalSellQuantity = 290 },
                new DashboardViewModel { TenantName = "Shop 5", Date = currentPreviousDateString, UnitRent = 90, ColorCode = "#417c3a", TotalIncome = 3490923, AreaSqft = 267.57, ProductMinPriceValue = 43, ProductMaxPriceValue = 345, TotalSellQuantity = 432 },
                new DashboardViewModel { TenantName = "Shop 1", Date = currentPreviousThreeMonthDateString, UnitRent = 20, ColorCode = "#FF5733", TotalIncome = 3458023, AreaSqft = 212.23, ProductMinPriceValue = 43, ProductMaxPriceValue = 467, TotalSellQuantity = 690 },
                new DashboardViewModel { TenantName = "Shop 2", Date = currentPreviousThreeMonthDateString, UnitRent = 40, ColorCode = "#196F3D", TotalIncome = 8904932, AreaSqft = 112.01, ProductMinPriceValue = 94, ProductMaxPriceValue = 542, TotalSellQuantity = 580 },
                new DashboardViewModel { TenantName = "Shop 3", Date = currentPreviousThreeMonthDateString, UnitRent = 60, ColorCode = "#34495E", TotalIncome = 7890421, AreaSqft = 321, ProductMinPriceValue = 53, ProductMaxPriceValue = 345, TotalSellQuantity = 358 },
                new DashboardViewModel { TenantName = "Shop 4", Date = currentPreviousThreeMonthDateString, UnitRent = 30, ColorCode = "#f0c0c0", TotalIncome = 4534320, AreaSqft = 178.3, ProductMinPriceValue = 32, ProductMaxPriceValue = 210, TotalSellQuantity = 205 },
                new DashboardViewModel { TenantName = "Shop 5", Date = currentPreviousThreeMonthDateString, UnitRent = 50, ColorCode = "#417c3a", TotalIncome = 23459094, AreaSqft = 267.57, ProductMinPriceValue = 33, ProductMaxPriceValue = 256, TotalSellQuantity = 345 }
            };

            return tenantList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}