using Microsoft.AspNetCore.Mvc;
using burger.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace burger.Controllers
{
    public class FoodMenuController : Controller
    {
        private readonly DataContext _context;

        public FoodMenuController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Burger()
        {
            var listOfBurgers = await _context.ViewBurger
                                 .Where(b => b.IsActive == true)
                                 .OrderByDescending(b => b.BurgerID)
                                 .ToListAsync();
            return View(listOfBurgers);
        }
    }
}
