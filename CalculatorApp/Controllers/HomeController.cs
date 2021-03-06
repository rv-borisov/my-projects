﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculatorApp.Models;
using System.Text.RegularExpressions;

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
            List<Operation> operations = db.Operations.ToList();
            operations.Reverse();
            return View(operations);
        }

        [HttpGet]
        public ActionResult Calculate(string input)
        {
            decimal result = Calc(input, out string edited);
            edited = edited.Replace("|", "");
            edited = edited.Replace(",", ".");

            Operation operation = new Operation()
            {
                Expression = edited,
                Result = result
            };
            db.Operations.Add(operation);
            db.SaveChanges();

            var post = new
            {
                result,
                edited
            };
            return Json(post);
        }


        /*[HttpPost]
        public void Calculate(string input, string result)
        {
            Operation operation = new Operation()
            {
                Expression = input,
                Result = Convert.ToDecimal(result)
            };
            db.Operations.Add(operation);
            db.SaveChanges();
        }*/
        public decimal Calc(string input, out string edited)
        {
            Stack<decimal> number = new Stack<decimal>();
            Stack<Symbol> sign = new Stack<Symbol>();
            decimal op1, op2;
            input = TransformInput(input);
            edited = input;
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
                        number.Push(Convert.ToDecimal(buffer));
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
                        if (OperationDictionary.operationDictionary.ContainsKey(buffer))
                        {
                            sign.Push(new Symbol(buffer));
                        }
                        else if (OperationDictionary.constDictionary.ContainsKey(buffer))
                        {
                            number.Push((decimal)OperationDictionary.constDictionary[buffer]);
                        }
                        buffer = "";
                    }
                }
                else
                {
                    if (input[i] == '(')
                    {
                        sign.Push(new Symbol(input[i].ToString()));
                    }
                    else if (input[i] == ')')
                    {
                        while (sign.Peek().GetOperationType() != "(")
                        {
                            if (sign.Peek().GetPriority() == 4)
                            {
                                op1 = number.Pop();
                                if (op1 == (decimal)Math.PI)
                                {
                                    op1 = 180;
                                }
                                number.Push(sign.Pop().GetResult(op1));
                            }
                            else
                            {
                                op2 = number.Pop();
                                op1 = number.Pop();
                                number.Push(sign.Pop().GetResult(op1, op2));
                            }
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
                                if (op1 == (decimal)Math.PI)
                                {
                                    op1 = 180;
                                }
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

        public string TransformInput(string input)
        {
            string result = "";
            string buffer = "";
            int countL = 0;
            int countR = 0;
            int j = 0;

            if (input == null || input[0] == '-' || input[0] == '+' || input[0] == '*' || input[0] == '/' 
                || input[0] == '.' || input[0] == ',')
            {
                input = "0" + input;
            }
            /*else if (input[0] == '(' || input[0] == ')')
            {
                input = "0+" + input;
            }*/
            input = input.Replace('.', ',');
            input = input.Replace(" ", "");
            input = input.Replace("p", "P");

            char[] ch = input.ToArray();
            while(ch[^1] == '-' || ch[^1] == '+' || ch[^1] == '*' || ch[^1] == '/')
            {
                Array.Resize(ref ch, ch.Length - 1);
            }
            input = new string(ch);
            input += "|";
            for (int i = 0; i < input.Length; i++)
            {
                if (j > 0 && j == i)
                {
                    result += ')';
                }
                if (char.IsLetter(input[i]))
                {
                    if (char.IsLetter(input[i + 1]))
                    {
                        buffer += input[i];
                        continue;
                    }
                    else
                    {
                        buffer += input[i];
                        if (OperationDictionary.operationDictionary.ContainsKey(buffer))
                        {
                            result += buffer;
                            if (input[i + 1] != '(')
                            {
                                result += '(';
                                j = 1;
                                while (!(input[i+j] == '-' || input[i + j] == '+' || input[i + j] == '*' || input[i + j] == '/'))
                                {
                                    j++;
                                }
                                j += i;
                            }
                        }
                        else if (OperationDictionary.constDictionary.ContainsKey(buffer))
                        {
                            result += buffer;
                        }
                        buffer = "";
                        continue;
                    }
                }
                else if (!char.IsLetterOrDigit(input[i]))
                {
                    if(input[i] == '(')
                    {
                        countL++;
                    }
                    if (input[i] == ')')
                    {
                        countR++;
                        if (countR > countL)
                        {
                            countR--;
                            continue;
                        }         
                    }
                    if (i + 1 < input.Length && input[i] == '(' && (input[i + 1] == '+' || input[i + 1] == '-'))
                    {
                        result += input[i] + "0";
                        continue;
                    }
                    else if ((input[i] == '-' && input[i + 1] == '+') || (input[i] == '+' && input[i + 1] == '-'))
                    {
                        result += '-';
                        i++;
                        continue;
                    }
                    else if (input[i] == '-' && input[i + 1] == '-')
                    {
                        result += '+';
                        i++;
                        continue;
                    }
                    else if (i != input.Length - 1 && input[i] == input[i + 1])
                    {
                        continue;
                    }
                }
                result += input[i];              
            }
            if (countL > countR)
            {
                for (int i = countR; i < countL; i++)
                {
                    result += ")";
                }
            }
            result = result.Replace("|","");
            result += "|";
            return result;
        }
    }
}
