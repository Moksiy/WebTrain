﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class OrderElement
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ItemID { get; set; }
        public int ItemsCount { get; set; }
        public decimal ItemPrice { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}