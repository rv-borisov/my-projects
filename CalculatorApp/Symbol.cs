using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Symbol
    {
        readonly Dictionary<string, int> dictionary = new OperationDictionary().dictionary;
        string OperationType { get; set; }
        int Priority { get; set; }
        public string GetOperationType()
        {
            return OperationType;
        }
        public int GetPriority()
        {
            return Priority;
        }
        public double GetResult(double op1, double op2)
        {
            return OperationType switch
            {
                "+" => op1 + op2,
                "-" => op1 - op2,
                "*" => op1 * op2,
                "/" => op1 / op2,
                "^" => Math.Pow(op1, op2),
                _ => 0
            };
        }
        public double GetResult(double op)
        {
            return OperationType switch
            {
                "sin" => Math.Sin(op),
                _ => 0
            };
        }
        public Symbol(string operationType)
        {
            OperationType = operationType;
            Priority = dictionary[OperationType];     
        }
    }
}
