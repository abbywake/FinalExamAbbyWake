using FinalExamAbbyWake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//controller page 
namespace FinalExamAbbyWake.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuotesDbContext Context { get; set; }
        public HomeController(ILogger<HomeController> logger, QuotesDbContext con)
        {
            _logger = logger;
            Context = con;
        }

        public IActionResult Index()
        {
            return View();
        }
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //HttpGet so the it will route to teh AddQuote
        [HttpGet]
        
        public IActionResult AddQuote()
        {
            return View();
        }

        //Post version so that it will actually add to the database when the "submit" button is clicked on. 
        [HttpPost]
        public IActionResult AddQuote(Quotes submittedForm)
        {
            //if it is valid, take what is passed through the submitted form, and then add it to the context and then save. 
            if (ModelState.IsValid)
            {
                Context.Quotes1.Add(submittedForm);
                Context.SaveChanges();
                return View("Index");
            }
            else
            {
                return View();
            }
        }


        //removing the quote IActionResult
        public IActionResult RemoveQuote(long david)
        {
            //taking what is passed in and making sure it can work with it, then it removes it once i is connected to the context. save. 
            IQueryable<Quotes> removingQuote = Context.Quotes1.Where(m => m.QuoteId == david);

            foreach (var i in removingQuote)
            {
                Context.Quotes1.Remove(i);
            }

            Context.SaveChanges();

            return View("Index", david);
        }

        //passing in the conext to view the quotes
        public IActionResult ViewQuotes()
        {
            return View(Context.Quotes1);
        }

        //passing in the information through "Hello" and then taking that information to pass it through to the view with the information to edit 
        public IActionResult EditQuote(long Hello)
        {
            Quotes editQuote = Context.Quotes1.Where(m => m.QuoteId == Hello).FirstOrDefault();

            return View(editQuote);
        }

        //making sure the correct information was all passed through and then updating that info 
        public IActionResult SubmitEditQuote(Quotes editQuote)
        {
            Quotes edit_quote = Context.Quotes1.Where(m => m.QuoteId == editQuote.QuoteId).FirstOrDefault();
           
            edit_quote.Quote = editQuote.Quote;
            edit_quote.AuthorFName= editQuote.AuthorFName;
            edit_quote.AuthorLName = editQuote.AuthorLName;
            edit_quote.Date = editQuote.Date;
            edit_quote.Subject = editQuote.Subject;
            edit_quote.Citation = editQuote.Citation;

            //save into the context/update
            Context.Quotes1.Update(edit_quote);
            Context.SaveChanges();
            return RedirectToAction("ViewQuotes");
        }

    }
}
