using CarCollection.DataAccess.IRepository;
using CarCollection.Models;
using CarCollection.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<SelectListItem> GetApplicationUserListForDropDown();
        void Update(ApplicationUser applicationUser);
    }
}
