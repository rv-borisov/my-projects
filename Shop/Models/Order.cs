using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid Customer_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Shipment_Date { get; set; }
        public int Order_Number { get; set; }
        public string Status { get; set; }
    }
}
