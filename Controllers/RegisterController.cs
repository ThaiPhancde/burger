using System.Runtime.CompilerServices;
using burger.Areas.Admin.Models;    
using burger.Models;
using burger.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminUser auser)
        {
            if(auser == null) return NotFound();

            var check = _context.AdminUser.Where(u => (u.UserName == auser.UserName)).FirstOrDefault();
            if (check != null)
            {
                Functions. _Message = "Username already exists";
                return RedirectToAction("Index", "Register");
            }

            Functions._Message = string.Empty;
            auser.Password = Functions.MD5Password(auser.Password);
            _context.AdminUser.Add(auser);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}