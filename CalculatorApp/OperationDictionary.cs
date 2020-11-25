using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class OperationDictionary
    {
        public static readonly Dictionary<string, int> operationDictionary = new Dictionary<string, int>()
        {
            {"|", 0},
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2},
            {"^", 3},
            {"(", 0},
            {")", 10},
            {"sin", 4},
            {"cos", 4},
            {"tg", 4},
            {"ctg", 4}
        };
        public static readonly Dictionary<string, double> constDictionary = new Dictionary<string, double>()
        {
            {"Pi", Math.PI},
            {"e", Math.E}
        };
    }
}
