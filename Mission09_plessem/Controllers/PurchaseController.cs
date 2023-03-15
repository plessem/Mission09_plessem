using Microsoft.AspNetCore.Mvc;
using Mission09_plessem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Checkouts()
        {
            return View(new Purchase());
        }
    }
}
