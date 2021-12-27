using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCollection.DataAccess.Repository;
using CarCollection.DataAccess.Repository.IRepository;
using CarCollection.Models;
using CarCollection.Models.ViewModels;
using System.Security.Claims;

namespace CarCollection.Pages.Customer.Home 
{ 
    public class IndexModel : PageModel 
    {
        private readonly IUnitOfWork _unitOfWork; public IndexModel(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        public IEnumerable<CarCollection.Models.Review> ReviewList { get; set; }
        public IEnumerable<Car> CarList { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string DemoVar { get; set; }
        public void OnGet()
        {
            ReviewList = _unitOfWork.Review.GetAll(null, null, "Car,ApplicationUser");
            CarList = _unitOfWork.Car.GetAll(null, q => q.OrderBy(c => c.Id), null);
            DemoVar = "I am the demo Session Variable from the Homepage!";
            HttpContext.Session.SetString("HOME", DemoVar);
        }
    } 
}
