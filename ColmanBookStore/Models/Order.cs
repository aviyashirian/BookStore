using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanBookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Costumer Costumer { get; set; }
        public OrderStatus Status { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string CCName { get; set; }
        public string CCNumber { get; set; }
        public string CCExpiration { get; set; }
        public string CCCvv { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
