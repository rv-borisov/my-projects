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
            double result = Calc(input);
            return Content(result.ToString());
        }


        public double Calc(string input)
        {
            Stack<double> number = new Stack<double>();
            Stack<Symbol> sign = new Stack<Symbol>();
            double op1, op2;
            if (input == null || input[0] == '-')
            {
                input = "0" + input;
            }
            input = input.Replace('.', ',');
            input += "|";
            string buffer = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]) || input[i] == ',')
                {
                    if (char.IsNumber(input[i + 1]) || input[i + 1] == ',')
                    {
                        buffer += input[i];
                    }
                    else
                    {
                        buffer += input[i];
                        number.Push(Convert.ToDouble(buffer));
                        buffer = "";
                    }
                }
                else if (char.IsLetter(input[i]))
                {
                    if (char.IsLetter(input[i + 1]))
                    {
                        buffer += input[i];
                    }
                    else
                    {
                        buffer += input[i];
                        if (new OperationDictionary().dictionary.ContainsKey(buffer))
                        {
                            sign.Push(new Symbol(buffer));
                            buffer = "";
                        }
                    }
                }
                else
                {
                    if(input[i] == '(')
                    {
                        sign.Push(new Symbol(input[i].ToString()));
                    }
                    else if (input[i] == ')')
                    {
                        while(sign.Peek().GetOperationType() != "(")
                        {
                            op2 = number.Pop();
                            op1 = number.Pop();
                            number.Push(sign.Pop().GetResult(op1, op2));
                        }
                        sign.Pop();
                    }
                    else if (!sign.Any() || new Symbol(input[i].ToString()).GetPriority() > sign.Peek().GetPriority())
                    {
                        sign.Push(new Symbol(input[i].ToString()));
                    }
                    else
                    {
                        
                        while (new Symbol(input[i].ToString()).GetPriority() <= sign.Peek().GetPriority())
                        {
                            if (sign.Peek().GetPriority() == 4)
                            {
                                op1 = number.Pop();
                                number.Push(sign.Pop().GetResult(op1));
                            }
                            else
                            {
                                op2 = number.Pop();
                                op1 = number.Pop();
                                number.Push(sign.Pop().GetResult(op1, op2));
                            }                         
                            if (sign.Count == 0)
                            {
                                break;
                            }
                        }
                        sign.Push(new Symbol(input[i].ToString()));
                    }
                }
            }
            return number.Pop();      
        }
    }
}
