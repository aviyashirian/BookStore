using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanBookStore.Models
{
    public class Branch
    {
        [Key]
        public int ID { get; set; }
        public string branchName { get; set; }
        public string addressInfo { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
