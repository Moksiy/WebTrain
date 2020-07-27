using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class Customer
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public double? Discount { get; set; }
    }
}