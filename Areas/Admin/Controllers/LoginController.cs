using burger.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using burger.Utilities;
using burger.Models;

namespace burger.Areas.Admin.Controllers{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context){
                _context = context; 
        }
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user){
            if(user == null) return NotFound();
            string pw = Functions.MD5Password(user.Password);
            var check = _context.AdminUser.Where(u => (u.UserName == user.UserName) && (u.Password == pw)).FirstOrDefault();
            if(check == null){
                Functions._Message = "Invalid username and password !";
                return RedirectToAction("Index", "Login");
            }
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty: check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}