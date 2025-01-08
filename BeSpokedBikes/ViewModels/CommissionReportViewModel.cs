namespace BeSpokedBikes.ViewModels
{
    public class CommissionReportViewModel
    {
        public string SalesPersonName { get; set; } = string.Empty;
        public string Quarter { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal TotalCommission => TotalSales * CommissionRate / 100;
    }
}
