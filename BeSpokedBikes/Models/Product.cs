using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public int QtyOnHand { get; set; }
        public decimal CommissionPercentage {  get; set; }
    }
}
