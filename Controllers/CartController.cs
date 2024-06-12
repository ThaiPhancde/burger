using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using burger.Models;
using Microsoft.AspNetCore.Http;
using burger.Extensions;

namespace burger.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}

