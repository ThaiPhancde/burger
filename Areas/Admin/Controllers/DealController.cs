using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DealsController : Controller
    {
        private readonly DataContext _context;

        public DealsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dealsList = _context.Deals.OrderBy(d => d.DealID).ToList();
            return View(dealsList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var deal = _context.Deals.Find(id);
            if (deal == null)
                return NotFound();
            return View(deal);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delDeal = _context.Deals.Find(id);
            if (delDeal == null)
                return NotFound();
            _context.Deals.Remove(delDeal);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(tblDeals deal)
        {
            if (ModelState.IsValid)
            {
                _context.Deals.Add(deal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deal);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var deal = _context.Deals.Find(id);
            if (deal == null)
                return NotFound();
            return View(deal);
        }

        [HttpPost]
        public IActionResult Edit(tblDeals deal)
        {
            if (ModelState.IsValid)
            {
                _context.Deals.Update(deal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deal);
        }
    }
}
