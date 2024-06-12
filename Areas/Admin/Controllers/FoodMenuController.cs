using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodMenuController : Controller
    {
        private readonly DataContext _context;

        public FoodMenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var burgers = _context.Burger.OrderByDescending(b => b.BurgerID);
            int pageSize = 5;
            PagedList<tblBurger> models = new(burgers, page, pageSize);
            if (models == null)
                return NotFound();
            return View(models);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var burger = _context.Burger.SingleOrDefault(b => b.BurgerID == id);
            if (burger == null)
                return NotFound();
            return View(burger);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delBurger = _context.Burger.SingleOrDefault(b => b.BurgerID == id);
            if (delBurger == null)
                return NotFound();
            _context.Burger.Remove(delBurger);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var mnList = _context.Menu.Select(m => new SelectListItem
            {
                Text = m.MenuName,
                Value = m.MenuID.ToString()
            }).ToList();
            mnList.Insert(0, new SelectListItem
            {
                Text = "--- select ---",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblBurger burger)
        {
            if (ModelState.IsValid)
            {
                _context.Burger.Add(burger);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(burger);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var burger = _context.Burger.SingleOrDefault(b => b.BurgerID == id);
            if (burger == null)
                return NotFound();

            var mnList = _context.Menu.Select(m => new SelectListItem
            {
                Text = m.MenuName,
                Value = m.MenuID.ToString()
            }).ToList();
            mnList.Insert(0, new SelectListItem
            {
                Text = "--- select ---",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;

            return View(burger);
        }

        [HttpPost]
        public IActionResult Edit(tblBurger burger)
        {
            if (ModelState.IsValid)
            {
                _context.Burger.Update(burger);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(burger);
        }
    }
}
