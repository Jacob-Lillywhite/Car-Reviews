using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CarCollection.Models.ViewModels
{
    public class ReviewVM
    {
        public Review Review { get; set; }
        public IEnumerable<SelectListItem> CarList { get;set; }
        public IEnumerable<SelectListItem> ApplicationUserList { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
