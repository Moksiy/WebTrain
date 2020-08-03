using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class Customer
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        public string Address { get; set; }
        public double? Discount { get; set; }
    }
}