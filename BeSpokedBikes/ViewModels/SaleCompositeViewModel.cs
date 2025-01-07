using BeSpokedBikes.Models;
using BeSpokedBikes.Services;

namespace BeSpokedBikes.ViewModels
{
    public class SaleCompositeViewModel
    {
        public required Sale Sale {  get; set; }
        public required List<Product> Products { get; set; }
        public required List<SalesPerson> SalesPersons { get; set; }
        public required List<Customer> Customers { get; set; }
        public required SalesViewModel SalesViewModel { get; set; }
    }
}
