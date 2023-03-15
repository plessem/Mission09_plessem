using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please enter a name. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an address first line. ")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "Please enter the city name. ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the state. ")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the zip code. ")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter the country. ")]
        public string Country { get; set; }

        
        public bool Anonymous { get; set; }
    }
}
