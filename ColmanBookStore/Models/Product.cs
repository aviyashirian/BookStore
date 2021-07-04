using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanBookStore.Models
{
    public class Product : IComparable<Product>
    {
        [Key]
        public int ID { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgPath { get; set; }
        public bool IsDeleted { get; set; }

        public int CompareTo(Product other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}
