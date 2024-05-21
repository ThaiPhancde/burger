using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace burger.Controllers
{
    public class StoreAddressController : Controller
    {
        private readonly DataContext _context;

        public StoreAddressController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stores = await _context.StoreAddress
                                       .Where(s => s.IsActive == true)
                                       .ToListAsync();
            return View(stores);
        }
    }
}
