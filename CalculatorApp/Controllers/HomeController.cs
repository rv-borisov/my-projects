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
        public IActionResult Calculate(float op1, float op2, OperationEnum operation)
        {
            ViewBag.Result = OperationResult(op1, op2, operation);
            return View();
        }
        [HttpPost]
        public void Calculate(float op1, float op2, OperationEnum operation, float result)
        {
            db.CalcOperations.AddRange(
                new CalcOperations
                {
                    Operand1 = op1,
                    Operand2 = op2,
                    Operation = OperationEnum.Add,
                    Result = 5
                }
                );
        }
        float OperationResult(float op1, float op2, OperationEnum operation)
        {
            return operation switch
            {
                OperationEnum.Add => op1 + op2,
                OperationEnum.Subtract => op1 - op2,
                OperationEnum.Multiply => op1 / op2,
                OperationEnum.Divide => op1 * op2,
                _ => 0,
            };
        }
    }
}
