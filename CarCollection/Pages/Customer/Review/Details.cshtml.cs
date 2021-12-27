using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCollection.Models;
using CarCollection.DataAccess.Repository.IRepository;
using CarCollection.Models.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CarCollection.Utility;
using CarCollection.Models.ViewModels;

namespace CarCollection.Pages.Customer.Review { 
    
    public class DetailsModel : PageModel {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Models.Review ReviewObj { get; set; }
        public ApplicationUser ApplicationUserObj { get; set; }
        public Car CarObj { get; set; }
        public void OnGet(int id)
        {
            ReviewObj = _unitOfWork.Review.GetFirstOrDefault(u => u.Id == id);
            ApplicationUserObj = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == ReviewObj.ApplicationUserId);
            CarObj = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == ReviewObj.CarId);


        }
    } 
}