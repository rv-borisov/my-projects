using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class OperationDictionary
    {
        public readonly Dictionary<string, int> dictionary = new Dictionary<string, int>()
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
            {"ctg", 4},
        };
    }
}
