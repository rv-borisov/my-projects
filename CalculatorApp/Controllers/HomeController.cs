using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        OperationContext db;
        public HomeController(OperationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.CalcOperations.ToList());
        }

        [HttpGet]
        public IActionResult Calculate(string input)
        {
            float result = Calc(input);
            return Content(result.ToString());
        }


        public float Calc(string input)
        {
            if (input[0] == '-')
            {
                input = "0" + input;
            }
            Stack<float> number = new Stack<float>();
            Stack<Operation> sign = new Stack<Operation>();
            float op1, op2;
            input += "|";
            string buffNumber = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]) || input[i] == ',')
                {
                    if (char.IsNumber(input[i + 1]) || input[i + 1] == ',')
                    {
                        buffNumber += input[i];
                    }
                    else
                    {
                        buffNumber += input[i];
                        number.Push(Convert.ToSingle(buffNumber));
                        buffNumber = "";
                    }
                }
                else
                {
                    if (!sign.Any() || new Operation(input[i]).GetPriority() > sign.Peek().GetPriority())
                    {
                        sign.Push(new Operation(input[i]));
                    }
                    else
                    {
                        while (new Operation(input[i]).GetPriority() <= sign.Peek().GetPriority())
                        {
                            op2 = number.Pop();
                            op1 = number.Pop(); 
                            number.Push(sign.Pop().GetResult(op1, op2));
                            if (sign.Count == 0)
                            {
                                break;
                            }
                        }
                        sign.Push(new Operation(input[i]));
                    }
                }
            }
            return number.Pop();      
        }
    }
}
