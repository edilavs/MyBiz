using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using MyBiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBiz.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Positions.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Positions.Add(position);
            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.Id == id);

            if (position==null)
            {
                return RedirectToAction("error", "dashboard");
            }

            return View(position);
        }
        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View("index");
            }

            Position existPosition = _context.Positions.FirstOrDefault(x => x.Id == position.Id);
        
            if (existPosition == null)
            {
                return RedirectToAction("error", "dashboard");
            }

            existPosition.Name = position.Name;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Position position = _context.Positions.FirstOrDefault(x => x.Id == id);

            if (position==null)
            {
                return RedirectToAction("error", "dashboard");
            }
            return View(position);

        }

        [HttpPost]
        public IActionResult Delete(Position position)
        {
           

            Position existPosition = _context.Positions.FirstOrDefault(x => x.Id == position.Id);
            if (existPosition==null)
            {
                return View("index");
            }

            _context.Positions.Remove(existPosition);
            _context.SaveChanges();


            return RedirectToAction("index");


        }
    }
}
