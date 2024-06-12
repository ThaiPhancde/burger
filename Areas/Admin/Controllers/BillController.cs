using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using burger.Models;
using Microsoft.AspNetCore.Http;


namespace burger.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

