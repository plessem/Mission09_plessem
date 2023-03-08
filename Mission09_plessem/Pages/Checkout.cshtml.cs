using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnGet()
        {
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            Basket = new Basket();

            Basket.AddItem(b, 1);
            return RedirectToPage();
        }
    }
}
