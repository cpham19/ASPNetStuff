using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fakebook.Models;
using Fakebook.Services;

namespace Fakebook.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService searchService;
        public SearchController(SearchService searchService)
        {
            this.searchService = searchService;
        }

        // This is the page that when the user clicks Search button for "first time" or when they type something in the url (Search/"Name of Person")
        [HttpGet]
        public IActionResult Index(string name)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (name == null || name == "")
                {
                    // Search all people if no parameter
                    ViewBag.Persons = searchService.GetPersons(User.Identity.GetPersonId());
                    return View();
                }
                else
                {
                    // Search for people based on given parameter
                    ViewBag.Persons = searchService.GetPersonsBasedOnName(User.Identity.GetPersonId(), name);
                    return View("Index", name);
                }
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        // This is the page that when the user uses the input box to search people
        [HttpPost]
        public IActionResult Search(string name)
        {
            ViewBag.Persons = searchService.GetPersonsBasedOnName(User.Identity.GetPersonId(), name);
            return View("Index", name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
