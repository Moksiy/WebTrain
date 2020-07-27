using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}