using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab5.Services;
using Lab5.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService contactService;

        public HomeController(IContactService contactService)
        {
            this.contactService = contactService;
        }


        public IActionResult Index()
        {
            return View(contactService.GetContacts());
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            return View(contactService.GetContact(id));
        }

        [HttpPost]
        public IActionResult View(int id, Contact contact)
        {

            string NewPropName = Request.Form["NewPropName"];
            string NewPropValue = Request.Form["NewPropValue"];
            Debug.WriteLine(NewPropName);
            Debug.WriteLine(NewPropValue);
            contactService.AddField(id, NewPropName, NewPropValue);
            return View(contactService.GetContact(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            contactService.AddContact(contact);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
