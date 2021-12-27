using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using CarCollection.DataAccess.Repository.IRepository;
using CarCollection.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCollection.Pages.Admin.Invoice
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
        public InvoiceVM InvoiceObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            InvoiceObj = new InvoiceVM()
            {
                Invoice = new Models.Invoice(),
                CarList = _unitOfWork.Car.GetCarListForDropDown(),
                ApplicationUserList = _unitOfWork.ApplicationUser.GetApplicationUserListForDropDown()
            };
            if (id != null)
            {
                InvoiceObj.Invoice = _unitOfWork.Invoice.GetFirstOrDefault(u => u.Id == id);
                if (InvoiceObj == null)
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
            if (InvoiceObj.Invoice.Id == 0) //If there's a brand new Invoice
            {
                _unitOfWork.Invoice.Add(InvoiceObj.Invoice);
            }
            else
            {
                _unitOfWork.Invoice.Update(InvoiceObj.Invoice);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}
