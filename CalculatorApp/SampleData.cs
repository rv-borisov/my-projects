using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApp.Models;

namespace CalculatorApp
{
    public static class SampleData
    {
        public static void Initialize(OperationContext context)
        { 
            if (!context.Operations.Any())
            {
                context.Operations.AddRange(
                    new Operation
                    {
                        Expression = "1+2",
                        Result = 3
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
