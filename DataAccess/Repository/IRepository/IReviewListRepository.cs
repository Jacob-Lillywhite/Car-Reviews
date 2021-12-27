using CarCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public interface IReviewListRepository
    {
        IQueryable<Review> Reviews { get; }
    }
}
