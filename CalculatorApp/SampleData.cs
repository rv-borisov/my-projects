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
            if (!context.CalcOperations.Any())
            {
                context.CalcOperations.AddRange(
                    new CalcOperations
                    {
                        Operand1 = 2,
                        Operand2 = 3,
                        Operation = OperationEnum.Add,
                        Result = 5
                    },
                    new CalcOperations
                    {
                        Operand1 = 2,
                        Operand2 = 3,
                        Operation = OperationEnum.Subtract,
                        Result = -1
                    },
                    new CalcOperations
                    {
                        Operand1 = 2,
                        Operand2 = 3,
                        Operation = OperationEnum.Multiply,
                        Result = 6
                    },
                    new CalcOperations
                    {
                        Operand1 = 2,
                        Operand2 = 3,
                        Operation = OperationEnum.Divide,
                        Result = 1.5f
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
