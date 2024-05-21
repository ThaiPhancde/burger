using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DealsController : Controller
{
    private readonly DataContext _context;

    public DealsController(DataContext context)
    {
        _context = context;
    }

    // GET: Deals/Index
    public async Task<IActionResult> Index()
    {
        var listOfDeals = await _context.Deals
            .Where(d => d.IsActive == true)
            .OrderByDescending(d => d.DealID)
            .ToListAsync();

        return View(listOfDeals);
    }
    public IActionResult Details(int id)
    {
        var deal = _context.Deals.FirstOrDefault(d => d.DealID == id);
        if (deal == null)
        {
            return NotFound();
        }
        return View(deal);
    }

}
