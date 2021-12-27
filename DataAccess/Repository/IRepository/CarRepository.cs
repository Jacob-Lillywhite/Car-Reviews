using CarCollection.DataAccess.Data;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCarListForDropDown()
        {
            return _db.Car.Select(i => new SelectListItem()
            {
                Text = i.carName,
                Value = i.Id.ToString()
            });
        }

        public void Update(CarCollection.Models.Car car)
        {
            var objFromDb = _db.Car.FirstOrDefault(s => s.Id == car.Id);
            objFromDb.Make = car.Make;
            objFromDb.Model = car.Model;
            objFromDb.Year = car.Year;
            objFromDb.Condition = car.Condition;
            objFromDb.Price = car.Price;

            _db.SaveChanges();
        }
    }
}
