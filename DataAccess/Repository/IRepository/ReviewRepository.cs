using CarCollection.DataAccess.Data;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CarCollection.Models.Review Review)
        {
            var objFromDb = _db.Review.FirstOrDefault(s => s.Id == Review.Id);
            objFromDb.Rating = Review.Rating;
            objFromDb.Description = Review.Description;
            objFromDb.CarId = Review.CarId;
            if (Review.Image != null)
            {
                objFromDb.Image = Review.Image;
            }
            _db.SaveChanges();
        }
    }
}
