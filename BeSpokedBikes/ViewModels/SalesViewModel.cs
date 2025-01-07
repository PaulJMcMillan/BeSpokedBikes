using BeSpokedBikes.Models;
using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.ViewModels
{
    public class SalesViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required List<SalesListViewModel> Sales { get; set; }
    }
}
