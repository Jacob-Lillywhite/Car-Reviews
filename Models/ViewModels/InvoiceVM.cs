using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarCollection.Models.ViewModels
{
    public class InvoiceVM
    {
        public Invoice Invoice { get; set; }
        public IEnumerable<SelectListItem> CarList { get;set; }
        public IEnumerable<SelectListItem> ApplicationUserList { get; set; }
    }
}
