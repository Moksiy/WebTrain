using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class OrderElement
    {
        [Key]
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ItemID { get; set; }
        public int ItemsCount { get; set; }

        [Column(TypeName = "money")]
        public decimal ItemPrice { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}