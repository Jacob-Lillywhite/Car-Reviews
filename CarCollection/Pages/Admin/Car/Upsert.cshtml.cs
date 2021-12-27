using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using CarCollection.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCollection.Pages.Admin.Car
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }
        [BindProperty]
        public Models.Car CarObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CarObj = new Models.Car();
            if (id != null)
            {
                CarObj = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == id);
                if(CarObj == null)
                {
                    return NotFound();
                }
            }
            return Page(); //Refreshes page onGet if there's no id passed in
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(CarObj.Id == 0) //If there's a brand new Car
            {
                _unitOfWork.Car.Add(CarObj);
            }
            else
            {
                _unitOfWork.Car.Update(CarObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
