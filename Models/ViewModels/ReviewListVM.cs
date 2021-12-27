using System;
using System.Collections.Generic;
using System.Text;
using CarCollection.Models;

namespace CarCollection.Models.ViewModels
{
    public class ReviewListVM
    {
        public IEnumerable<Review> Reviews { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
