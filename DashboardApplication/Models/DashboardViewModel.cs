namespace DashboardApplication.Models
{
    public class DashboardViewModel
    {
        public String? TenantName { get; set; }
        public Double ProductMinPriceValue { get; set; }
        public Double ProductMaxPriceValue { get; set; }
        public Double ProductAvgValue { get; set; }
        public int TotalSellQuantity { get; set; }
        public String? ColorCode { get; set; }
        public int? UnitRent { get; set; }
        public int? TotalIncome { get; set; }
        public String? Date { get; set; }
        public Double? AreaSqft { get; set; }
    }
}
