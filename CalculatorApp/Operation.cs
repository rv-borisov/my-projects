using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Operation
    {
        char OperationType { get; set; }
        int Priority { get; set; }
        public char GetOperationType()
        {
            return OperationType;
        }
        public int GetPriority()
        {
            return Priority;
        }
        public float GetResult(float op1, float op2)
        {
            return OperationType switch
            {
                '+' => op1 + op2,
                '-' => op1 - op2,
                '*' => op1 * op2,
                '/' => op1 / op2,
                '^' => op1 * op1,
                _ => 0,
            };
        }
        private readonly Dictionary<char, int> dictionary = new Dictionary<char, int>()
        {
            {'|', 0},
            {'+', 1},
            {'-', 1},
            {'*', 2},
            {'/', 2},
            {'^', 3}
        };        
        public Operation(char operationType)
        {
            OperationType = operationType;
            Priority = dictionary[OperationType];     
        }
    }
}
