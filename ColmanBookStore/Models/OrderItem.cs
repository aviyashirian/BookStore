using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanBookStore.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        [Key]
        public Order Order { get; set; }
        [Key]
        public Product Product { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
    }
}
