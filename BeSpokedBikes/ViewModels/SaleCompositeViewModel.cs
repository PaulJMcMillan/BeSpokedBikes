using BeSpokedBikes.Models;
using BeSpokedBikes.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeSpokedBikes.ViewModels
{
    public class SaleCompositeViewModel
    {
        public required IEnumerable<SelectListItem> Products { get; set; }
        public required IEnumerable<SelectListItem> SalesPersons { get; set; }
        public required IEnumerable<SelectListItem> Customers { get; set; }
        public required Sale Sale { get; set; }
    }
}
