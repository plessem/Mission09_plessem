using Microsoft.AspNetCore.Mvc;
using Mission09_plessem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CategoriesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //select category types
            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x); //default order
            return View(categories);
        }
    }
}
