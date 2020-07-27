using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTrain.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}