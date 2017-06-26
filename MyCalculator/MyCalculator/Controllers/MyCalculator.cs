using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCalculator.Calculator;

namespace MyCalculator.Controllers
{
    public class MyCalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string operationText)
        {
            List<char> operators;
            string[] operands;
            try
            {
                Calculation.GetOperatorsAndOperands(operationText, out operators, out operands);
                double result = Calculation.GetResult(operators, operands);
                ViewBag.operationResult = result;
            }
            catch
            {
                ViewBag.operationResult = operationText;
                ViewBag.errorFlag = 1;
            }
            return View();
        }

    }
}