﻿namespace WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

}
