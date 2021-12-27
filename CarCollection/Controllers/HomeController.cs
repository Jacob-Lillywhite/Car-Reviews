using Microsoft.AspNetCore.Mvc;
using CarCollection.Models;
using System.Linq;
using CarCollection.Models.ViewModels;
using CarCollection.DataAccess.Repository.IRepository;

namespace CarCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public int PageSize = 1;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index(string carName, int reviewPage = 1)
            => View(new ReviewVM
            {
                Reviews = _unitOfWork.ReviewList.Reviews
                    .Where(p => carName == null || p.CarName == carName)
                    .OrderBy(p => p.Id)
                    .Skip((reviewPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = reviewPage,
                    ItemsPerPage = PageSize,
                    TotalItems = carName == null ?
                        _unitOfWork.ReviewList.Reviews.Count() :
                        _unitOfWork.ReviewList.Reviews.Where(e =>
                            e.CarName == carName).Count()
                },
                CurrentCategory = carName
            });
    }
}
