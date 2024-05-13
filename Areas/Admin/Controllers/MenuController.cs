using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Menu.OrderBy(m => m.MenuID).ToList();
            return View(mnList);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Menu.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            var delMenu = _context.Menu.Find(id);
            if (delMenu == null)
                return NotFound();
            _context.Menu.Remove(delMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Create()
        {
            var mmList = (from m in _context.Menu
                          select new SelectListItem()
                          {
                              Text = (m.Levels == 1) ? m.MenuName : "-- " + m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mmList.Insert(0, new SelectListItem()
            {
                Text = "--- select ---",
                Value = "0"
            });
            ViewBag.mmList = mmList;
            return View();
        }

        [HttpPost]
        [Obsolete("references")]
        public IActionResult Create(tblMenu mm)
        {
            if (ModelState.IsValid)
            {
                _context.Menu.Add(mm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mm);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
                return NotFound();
            var mn = _context.Menu.Find(id);
            if(mn == null)
                return NotFound();
            var mnList = (from m in _context.Menu
                        select new SelectListItem()
                        {
                            Text = (m.Levels == 1) ? m.MenuName : "-- " + m.MenuName,
                            Value = m.MenuID.ToString()
                        }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- select ---",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        public IActionResult Edit(tblMenu mn){
            if (ModelState.IsValid)
            {
                _context.Menu.Update(mn);
                _context.SaveChanges();
                return  RedirectToAction("Index");
            }
            return View(mn);
        }
    }   
}