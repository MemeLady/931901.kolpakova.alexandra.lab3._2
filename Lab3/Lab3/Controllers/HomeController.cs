using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        static Quiz quiz = new Quiz();

        static Dictionary<int, string> operations = new Dictionary<int, string>
        {
            {0, "+"},
            {1, "-"},
            {2, "*"},
        };

        int answer;

        private (int, string) RandomizeValues()
        {
            Random rand = new Random();
            int first = rand.Next(0, 25);
            int second = rand.Next(0, 25);
            var operation = operations[rand.Next(0, 3)];

            switch (operation)
            {
                case "+":
                    answer = first + second; break;
                case "-":
                    answer = first - second; break;
                case "*":
                    answer = first * second; break;
            };
            string value = first + " " + operation + " " + second;

            return (answer, value);
        }

        private void UpdateValue()
        {

        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) { _logger = logger; }

        public IActionResult Index() { return View(); }

        public IActionResult Quiz()
        {
            quiz.ResetCurrentValue();
            (ViewBag.Answer, ViewBag.Value) = RandomizeValues();
            return View();
        }
        public IActionResult QuizResult()
        {
            ViewBag.RightAnswersCount = quiz.rightAnswersCount;
            ViewBag.AnswersCount = quiz.answersCount;
            ViewBag.Results = quiz.Results;

            return View();
        }

        [HttpPost]
        public IActionResult QuizNext(int hanswer, string hexpression, int answer)
        {
            quiz.UpdateValue(hanswer, hexpression, answer);
            (ViewBag.Answer, ViewBag.Value) = RandomizeValues();
            return View("Quiz");
        }

        public IActionResult QuizFinish(int hanswer, string hexpression, int answer)
        {
            quiz.UpdateValue(hanswer, hexpression, answer);

            ViewBag.RightAnswersCount = quiz.curRightAnswersCount;
            ViewBag.AnswersCount = quiz.curAnswersCount;
            ViewBag.Results = quiz.curResults;
            return View("QuizResult");
        }
    }
}
