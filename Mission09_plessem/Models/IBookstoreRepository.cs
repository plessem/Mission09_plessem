using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem.Models
{
    //interface -- not a class but a template for a class 
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
