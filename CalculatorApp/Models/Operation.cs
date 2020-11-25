using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public decimal Result { get; set; }
    }
}
