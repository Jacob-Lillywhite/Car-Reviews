using CarCollection.DataAccess.Data;
using CarCollection.DataAccess.Repository;
using CarCollection.Models;
using CarCollection.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDelivery.DataAccess.Repository.IRepository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicationUserListForDropDown()
        {
            return _db.ApplicationUser.Select(i => new SelectListItem()
            {
                Text = i.FullName,
                Value = i.Id.ToString()
            });
        }


        public void Update(CarCollection.Models.Models.ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(s => s.Id == applicationUser.Id);
            objFromDb.FirstName = applicationUser.FirstName;
            objFromDb.LastName = applicationUser.LastName;
            objFromDb.Email = applicationUser.Email;
            objFromDb.PhoneNumber = applicationUser.PhoneNumber;

            _db.SaveChanges();
        }
    }
}
