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
        private IPurchaseRepository repo { get; set; }
        private Basket Basket { get; set; }

        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }

        [HttpGet]
        public IActionResult Checkouts()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkouts(Purchase purchase)
        {
            //if basket is empty, tell the user
            if(Basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            
            if (ModelState.IsValid)
            {
                purchase.Lines = Basket.Items.ToArray();
                repo.SavePurchase(purchase);
                Basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }

            
        }
    }
}
