namespace DashboardApplication.Models
{
    public class DashboardViewModel
    {
        public string? TenantName { get; set; }
        public double ProductMinPriceValue { get; set; }
        public double ProductMaxPriceValue { get; set; }
        public double ProductAvgValue { get; set; }
        public int TotalSellQuantity { get; set; }
        public string? ColorCode { get; set; }
        public int? UnitRent { get; set; }
        public int? TotalIncome { get; set; }
        public string? Date { get; set; }
        public double? AreaSqft { get; set; }
    }
}
