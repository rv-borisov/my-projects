using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid Order_Id { get; set; }
        public Guid Item_Id { get; set; }
        public int Items_Count { get; set; }
        public decimal Item_Price { get; set; }
    }
}
