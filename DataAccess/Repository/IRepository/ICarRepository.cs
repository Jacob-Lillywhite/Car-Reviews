using CarCollection.DataAccess.IRepository;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<SelectListItem> GetCarListForDropDown();
        void Update(Car car);
    }
}
