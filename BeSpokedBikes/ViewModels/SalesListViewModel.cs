namespace BeSpokedBikes.ViewModels
{
    public class SalesListViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public string SalesPerson { get; set; }=string.Empty;
        public string Customer { get; set;} = string.Empty;
        public DateTime SalesDate { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Commission { get; set; }
        public decimal DiscountPercentage {  get; set; }
        public decimal DiscountPrice => SalesPrice - (SalesPrice * DiscountPercentage / 100);
    }
}
