using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers.ToList();

            return View(blah);
        }

        public IActionResult Admin()
        {
            var blah = _context.Bowlers.ToList();

            return View(blah);
        }
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Page = "Edit";

            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("Edit", bowler);
        }
        [HttpPost]
        public IActionResult Edit (Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

            return View("Confirmation");
        }
        [HttpGet]
        public IActionResult Delete (int bowlerid)
        {
            ViewBag.Page = "Delete";

            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("Delete", bowler);
        }
        [HttpPost]
        public IActionResult Delete (Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

            return View("Confirmation");
        }

        [HttpGet]
        public IActionResult NewBowler()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult NewBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

            return View("Confirmation");
        }
        

    }

    
}
