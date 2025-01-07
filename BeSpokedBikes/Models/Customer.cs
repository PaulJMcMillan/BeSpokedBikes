using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }= string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; }=string.Empty;
        public DateTime StartDate { get; set; }


    }
}
