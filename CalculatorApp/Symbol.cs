using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Symbol
    {
        readonly Dictionary<string, int> dictionary = OperationDictionary.dictionary;
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
        public decimal GetResult(decimal op1, decimal op2)
        {
            return OperationType switch
            {
                "+" => op1 + op2,
                "-" => op1 - op2,
                "*" => op1 * op2,
                "/" => op1 / op2,
                "^" => (decimal)Math.Pow((double)op1, (double)op2),
                _ => 0
            };
        }
        public decimal GetResult(decimal op)
        {
            double gradus = (double)op;
            double radian = (gradus / 180) * Math.PI;
            return OperationType switch
            {
                "sin" => (decimal)Math.Sin(radian),
                "cos" => (decimal)Math.Cos(radian),
                "tg" => (decimal)Math.Tan(radian),
                "ctg" => (decimal)(1 /Math.Tan(radian)),
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
