﻿using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SalesPersonId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SalesDate { get; set; }= DateTime.Now;
    }
}
