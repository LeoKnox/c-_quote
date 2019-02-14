using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quoting_dojo.Models;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Quotes")]
        [HttpPost]
        public IActionResult Quotes(MyModel quotes)
        {
            if (ModelState.IsValid) {
                System.Console.WriteLine(quotes.quoteName);
                string query = $"INSERT INTO quotes (quoteName, quoteQuote) VALUES ('{quotes.quoteName}', '{quotes.quoteQuote}')";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
            else
            {
                return View("Index");
            }
        }

        [Route("Quotes")]
        [HttpGet]
        public IActionResult Skip()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM Quotes ORDER BY MyModelId DESC");
            ViewBag.Quotes = AllQuotes;
            return View("Quotes");
        }
    }
}
