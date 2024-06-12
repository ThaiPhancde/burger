using burger.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Combo()
        {
            var listOfCombos = await _context.ViewCombo
                                .Where(c => c.IsActive == true)
                                .OrderByDescending(c => c.ComboID)
                                .ToListAsync();
            return View(listOfCombos);
        }

        public async Task<IActionResult> FriedChicken()
        {
            var listOfFriedChickens = await _context.ViewFriedChicken
                                           .Where(f => f.IsActive == true)
                                           .OrderByDescending(f => f.FriedChickenID)
                                           .ToListAsync();
            return View(listOfFriedChickens);
        }

        public async Task<IActionResult> Drink()
        {
            var listOfDrink = await _context.ViewDrink
                                    .Where(k => k.IsActive == true)
                                    .OrderByDescending(k => k.DrinkID)
                                    .ToListAsync();
            return View(listOfDrink);
        }
        public async Task<IActionResult> HappySnack()
        {
            var listOfHappySnack = await _context.ViewHappySnack
                                    .Where(k => k.IsActive == true)
                                    .OrderByDescending(k => k.HappySnackID)
                                    .ToListAsync();
            return View(listOfHappySnack);
        }

      
    }
}