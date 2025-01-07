using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class SalesPerson
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Manager { get; set; } = string.Empty;
    }
}
