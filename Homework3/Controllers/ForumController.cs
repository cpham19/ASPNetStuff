using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Routing;

namespace Homework3.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService forumService;

        public ForumController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public IActionResult Index()
        {
            return View(forumService.GetForums());
        }

        public IActionResult ViewForum(int id)
        {
            return View(forumService.GetForum(id));
        }

        public IActionResult ViewTopic(int id, int id2)
        {
            return View(forumService.GetTopic(id, id2));
        }

        [HttpGet]
        public IActionResult AddForum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddForum(Forum f)
        {
            forumService.AddForum(f);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddTopic(int id)
        {
            ViewBag.id = id;
            return View();
        }
        

        [HttpPost]
        public IActionResult AddTopic(int id, Topic t)
        {
            t.ForumId = id;
            t.TopicDate = DateTime.Now;
            Debug.WriteLine(t.ForumId);
            forumService.AddTopic(t);
            return Redirect("/Forum/View/" + id);
        }

        [HttpGet]
        public IActionResult AddReply(int id, int id2)
        {
            ViewBag.id = id;
            ViewBag.id2 = id2;
            return View();
        }

        [HttpPost]
        public IActionResult AddReply(int id, int id2, Reply r)
        {
            r.ReplyDate = DateTime.Now;
            r.TopicId = id2;
            forumService.AddReply(r);
            return Redirect("/Forum/View/" + id + "/" + id2 + "/");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
