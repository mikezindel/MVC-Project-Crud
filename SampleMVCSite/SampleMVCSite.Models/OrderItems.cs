﻿
using System.ComponentModel.DataAnnotations;
namespace SampleMVCSite.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
