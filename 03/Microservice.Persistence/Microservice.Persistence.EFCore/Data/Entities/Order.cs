// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Microservice.Persistence.EFCore.Data.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public string Description { get; set; }
        public string MyField { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}