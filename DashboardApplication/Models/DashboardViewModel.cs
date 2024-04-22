namespace DashboardApplication.Models
{
    public class DashboardViewModel
    {
        public string? TenantName { get; set; }
        public double ProductMinPriceValue { get; set; }
        public double ProductMaxPriceValue { get; set; }
        public double ProductAvgValue { get; set; }
        public int TotalSalesQuantity { get; set; }
        public string? ColorCode { get; set; }
        public int? UnitRent { get; set; }
        public double TotalIncome { get; set; } = 0;
        public string? IncomeMonthDate { get; set; }
        public double? AreaSqft { get; set; }
        public List<DashboardViewModel> SetDashboardDetail { get; set; } = null!;

        public List<DashboardViewModel> GetDashboardDetail()
        {

            DateTime currntDateTime = DateTime.Now;
            string currentDateString = "2023-1-1";
            string currentPreviousDateString = "2022-12-31";
            string currentPreviousThreeMonthDateString = "2022-11-1";
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
                new DashboardViewModel { TenantName = "Shop 1", IncomeMonthDate = currentDateString, UnitRent = 30, ColorCode = "#FF5733", TotalIncome = 5034000, AreaSqft = 212.23, ProductMinPriceValue = 30, ProductMaxPriceValue = 324, TotalSalesQuantity = 360 },
                new DashboardViewModel { TenantName = "Shop 2", IncomeMonthDate = currentDateString, UnitRent = 80, ColorCode = "#196F3D", TotalIncome = 8793351, AreaSqft = 112.01, ProductMinPriceValue = 120, ProductMaxPriceValue = 672, TotalSalesQuantity = 474 },
                new DashboardViewModel { TenantName = "Shop 3", IncomeMonthDate = currentDateString, UnitRent = 50, ColorCode = "#34495E", TotalIncome = 4567135, AreaSqft = 321, ProductMinPriceValue = 25, ProductMaxPriceValue = 263, TotalSalesQuantity = 309 },
                new DashboardViewModel { TenantName = "Shop 4", IncomeMonthDate = currentDateString, UnitRent = 40, ColorCode = "#f0c0c0", TotalIncome = 3583120, AreaSqft = 178.3, ProductMinPriceValue = 15, ProductMaxPriceValue = 193, TotalSalesQuantity = 290 },
                new DashboardViewModel { TenantName = "Shop 5", IncomeMonthDate = currentDateString, UnitRent = 20, ColorCode = "#417c3a", TotalIncome = 6392000, AreaSqft = 267.57, ProductMinPriceValue = 63, ProductMaxPriceValue = 442, TotalSalesQuantity = 386 },
                new DashboardViewModel { TenantName = "Shop 1", IncomeMonthDate = currentPreviousDateString, UnitRent = 10, ColorCode = "#FF5733", TotalIncome = 4803983, AreaSqft = 212.23, ProductMinPriceValue = 30, ProductMaxPriceValue = 654, TotalSalesQuantity = 405 },
                new DashboardViewModel { TenantName = "Shop 2", IncomeMonthDate = currentPreviousDateString, UnitRent = 50, ColorCode = "#196F3D", TotalIncome = 7837263, AreaSqft = 112.01, ProductMinPriceValue = 110, ProductMaxPriceValue = 532, TotalSalesQuantity = 470 },
                new DashboardViewModel { TenantName = "Shop 3", IncomeMonthDate = currentPreviousDateString, UnitRent = 20, ColorCode = "#34495E", TotalIncome = 6432903, AreaSqft = 321, ProductMinPriceValue = 34, ProductMaxPriceValue = 352, TotalSalesQuantity = 320 },
                new DashboardViewModel { TenantName = "Shop 4", IncomeMonthDate = currentPreviousDateString, UnitRent = 50, ColorCode = "#f0c0c0", TotalIncome = 5323412, AreaSqft = 178.3, ProductMinPriceValue = 10, ProductMaxPriceValue = 234, TotalSalesQuantity = 290 },
                new DashboardViewModel { TenantName = "Shop 5", IncomeMonthDate = currentPreviousDateString, UnitRent = 90, ColorCode = "#417c3a", TotalIncome = 3490923, AreaSqft = 267.57, ProductMinPriceValue = 43, ProductMaxPriceValue = 345, TotalSalesQuantity = 432 },
                new DashboardViewModel { TenantName = "Shop 1", IncomeMonthDate = currentPreviousThreeMonthDateString, UnitRent = 20, ColorCode = "#FF5733", TotalIncome = 3458023, AreaSqft = 212.23, ProductMinPriceValue = 43, ProductMaxPriceValue = 467, TotalSalesQuantity = 690 },
                new DashboardViewModel { TenantName = "Shop 2", IncomeMonthDate = currentPreviousThreeMonthDateString, UnitRent = 40, ColorCode = "#196F3D", TotalIncome = 8904932, AreaSqft = 112.01, ProductMinPriceValue = 94, ProductMaxPriceValue = 542, TotalSalesQuantity = 580 },
                new DashboardViewModel { TenantName = "Shop 3", IncomeMonthDate = currentPreviousThreeMonthDateString, UnitRent = 60, ColorCode = "#34495E", TotalIncome = 7890421, AreaSqft = 321, ProductMinPriceValue = 53, ProductMaxPriceValue = 345, TotalSalesQuantity = 358 },
                new DashboardViewModel { TenantName = "Shop 4", IncomeMonthDate = currentPreviousThreeMonthDateString, UnitRent = 30, ColorCode = "#f0c0c0", TotalIncome = 4534320, AreaSqft = 178.3, ProductMinPriceValue = 32, ProductMaxPriceValue = 210, TotalSalesQuantity = 205 },
                new DashboardViewModel { TenantName = "Shop 5", IncomeMonthDate = currentPreviousThreeMonthDateString, UnitRent = 50, ColorCode = "#417c3a", TotalIncome = 23459094, AreaSqft = 267.57, ProductMinPriceValue = 33, ProductMaxPriceValue = 256, TotalSalesQuantity = 345 }
            };

            return tenantList;
        }
    }
}
