using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using CarCollection.DataAccess.Repository.IRepository;
using CarCollection.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CarCollection.Pages.Customer.Review
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
        public ReviewVM ReviewObj { get; set; }
        public string UserId { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != null)
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            ReviewObj = new ReviewVM()
            {
                Review = new Models.Review(),
                CarList = _unitOfWork.Car.GetCarListForDropDown(),
                ApplicationUserList = _unitOfWork.ApplicationUser.GetApplicationUserListForDropDown()

            };
            if (id != null)
            {
                ReviewObj.Review = _unitOfWork.Review.GetFirstOrDefault(u => u.Id == id);
                if (ReviewObj == null)
                {
                    return NotFound();
                }
            }
            return Page(); //Refreshes page onGet if there's no id passed in
        }
        public IActionResult OnPost()
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ReviewObj.Review.Id == 0) //If there's a brand new Review Item
            {
                //Physically upload and save
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\reviews");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                //save the string data path
                ReviewObj.Review.Image = @"\images\reviews\" + fileName + extension;
                _unitOfWork.Review.Add(ReviewObj.Review);
            }
            else //UPDATE
            {
                var objFromDb = _unitOfWork.Review.Get(ReviewObj.Review.Id);
                if (files.Count > 0)
                {
                    //Physically upload and save
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\reviews");
                    var extension = Path.GetExtension(files[0].FileName);
                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //save the string data path
                    ReviewObj.Review.Image = @"\images\reviews\" + fileName + extension;
                }
                else
                {
                    ReviewObj.Review.Image = objFromDb.Image;
                }
                _unitOfWork.Review.Update(ReviewObj.Review);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");

        }
    }
}
