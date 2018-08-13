using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleChatApp.Data;
using SimpleChatApp.Models;

namespace SimpleChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChatContext _db;

        public HomeController(ChatContext db)
        {
            _db = db;
        }

        public IActionResult Welcome()
        {
            return View(_db.Messages.Include(m => m.User));
        }

        public IActionResult Index()
        {
            var ms = _db.Messages.Select(m=>$"{m.Text}\n{m.When}").ToArray();
            var protocol = String.Join("\n", ms);
            return Content("Chat:\n" + protocol);
            //return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Message mes)
        {
            mes.UserId = 1;
            mes.When = DateTime.Now;

            _db.Add(mes);
            _db.SaveChanges();

            return RedirectPermanent("~/Home/Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
