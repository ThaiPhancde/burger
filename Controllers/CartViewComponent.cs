using burger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace burger.ViewComponents
{
    [ViewComponent(Name = "CartView")] // Apply the ViewComponent attribute
    public class CartViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public CartViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await _context.CartItem.ToListAsync(); 
            return View(cartItems); 
        }
    }
}
