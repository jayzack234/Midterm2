using Microsoft.AspNetCore.Mvc;
using Midterm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm2.Controllers
{
    public class HomeController : Controller
    {
        //Bringin a QuoteListContext
        private QuoteListContext context { get; set; }
        //Constructor that build instance of QuoteListContext
        public HomeController(QuoteListContext con)
        {
            context = con;
        }
        public IActionResult Index()
        {
            return View(context.Quotes);
        }
        public IActionResult Random()
        {
            return View(context.Quotes);
        }

        [HttpGet]
        public IActionResult EnterQuote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterQuote(QuoteItem q)
        {
            //Passes a model that will add the entry to the database
            //Adds the EnterQuote info that was passed in
            if (ModelState.IsValid)
            {
                context.Quotes.Add(q);
                context.SaveChanges();
            }
            return View();
        }
        //The ability to edit a submission using get and post
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //match up passed id with id stored in database
            var quote = context.Quotes.Where(s => s.QuoteId == id).FirstOrDefault();

            return View(quote);
        }
        [HttpPost]
        public IActionResult Edit(QuoteItem task)
        {
            //match up passed id with id stored in database
            var mov = context.Quotes.Where(s => s.QuoteId == task.QuoteId).FirstOrDefault();

            context.Quotes.Remove(mov);
            context.Quotes.Add(task);

            //Save changes
            context.SaveChanges();
            //Make sure these changes make it to the display page, and context.tasks coordinates with what is in the dbcontext file
            return RedirectToAction("Index", context.Quotes);
        }
        //The ability to delete a submission
        public IActionResult Delete(int id)
        {
            //match up passed id with id stored in database
            var quote = context.Quotes.Where(s => s.QuoteId == id).FirstOrDefault();

            //Use the remove functionality built into ASP
            context.Quotes.Remove(quote);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
