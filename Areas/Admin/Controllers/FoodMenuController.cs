using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burger.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        // Common method to get menu list for dropdowns
        private List<SelectListItem> GetMenuList()
        {
            var mnList = (from m in _context.FoodMenu
                          select new SelectListItem()
                          {
                              Text = m.FMenuName,
                              Value = m.FMenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- select ---",
                Value = string.Empty
            });
            return mnList;
        }

        public IActionResult Index(int page = 1)
        {
            return View();
        }

        public IActionResult GetProductsByType(string type, int page = 1)
        {   
            ViewBag.Type = type;
            IQueryable<object> allProducts = null;
            switch (type)
            {
                case "Burger":
                    allProducts = _context.Burger.Cast<object>();
                    break;
                case "Combo":
                    allProducts = _context.Combo.Cast<object>();
                    break;
                case "FriedChicken":
                    allProducts = _context.FriedChicken.Cast<object>();
                    break;
                case "Drink":
                    allProducts = _context.Drink.Cast<object>();
                    break;
                case "HappySnack":
                    allProducts = _context.HappySnack.Cast<object>();
                    break;
                default:
                    allProducts = _context.Burger.Cast<object>()
                        .Concat(_context.Combo.Cast<object>())
                        .Concat(_context.FriedChicken.Cast<object>())
                        .Concat(_context.Drink.Cast<object>())
                        .Concat(_context.HappySnack.Cast<object>());
                    break;
            }

            allProducts = allProducts.OrderByDescending(p => p.GetType().GetProperty("ID").GetValue(p, null));

            int pageSize = 5;
            PagedList<object> models = new(allProducts, page, pageSize);
            return PartialView("_ProductList", models);
        }

        // Burger Actions
        public IActionResult CreateBurger()
        {
            ViewBag.mnList = GetMenuList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateBurger(tblBurger burger)
        {
            if (ModelState.IsValid)
            {
                _context.Burger.Add(burger);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mnList = GetMenuList();
            return View(burger);
        }

        // Drink Actions
        public IActionResult CreateDrink()
        {
            ViewBag.mnList = GetMenuList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateDrink(tblDrink drink)
        {
            if (ModelState.IsValid)
            {
                _context.Drink.Add(drink);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mnList = GetMenuList();
            return View(drink);
        }

        // FriedChicken Actions
        public IActionResult CreateFriedChicken()
        {
            ViewBag.mnList = GetMenuList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateFriedChicken(tblFriedChicken friedChicken)
        {
            if (ModelState.IsValid)
            {
                _context.FriedChicken.Add(friedChicken);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mnList = GetMenuList();
            return View(friedChicken);
        }

        // Combo Actions
        public IActionResult CreateCombo()
        {
            ViewBag.mnList = GetMenuList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCombo(tblCombo combo)
        {
            if (ModelState.IsValid)
            {
                _context.Combo.Add(combo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mnList = GetMenuList();
            return View(combo);
        }

        // HappySnack Actions
        public IActionResult CreateHappySnack()
        {
            ViewBag.mnList = GetMenuList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateHappySnack(tblHappySnack happySnack)
        {
            if (ModelState.IsValid)
            {
                _context.HappySnack.Add(happySnack);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mnList = GetMenuList();
            return View(happySnack);
        }
    }
}