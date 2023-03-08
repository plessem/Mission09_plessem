using Microsoft.AspNetCore.Mvc;
using Mission09_plessem.Models;
using Mission09_plessem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        //setting default to page 1, if nothing comes in
        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            //how many results you want on a page
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b=>b.Category == categoryType || categoryType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (categoryType == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x=> x.Category == categoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
