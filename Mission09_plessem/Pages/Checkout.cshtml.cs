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
        public CheckoutModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returlUrl)
        {
            ReturnUrl = returlUrl ?? "/";
          

        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //add item to the basket
            Basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Basket.RemoveItem(Basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage ( new {ReturnIrl = returnUrl});

        }
    }
}
