using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_plessem.Infrastructure;
using Mission09_plessem.Models;

namespace Mission09_plessem.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public CheckoutModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returlUrl)
        {
            ReturnUrl = returlUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //use basket if it already exists, else create a new one
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            //add item to the basket
            Basket.AddItem(b, 1);

            //set json value to whats in the basket
            HttpContext.Session.SetJson("Basket", Basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
