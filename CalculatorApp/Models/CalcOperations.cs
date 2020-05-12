using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public class CalcOperations
    {
        public int Id { get; set; }
        public float Operand1 { get; set; }
        public float Operand2 { get; set; }
        public OperationEnum Operation { get; set; }
        public float Result { get; set; }
    }
    public enum OperationEnum
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
