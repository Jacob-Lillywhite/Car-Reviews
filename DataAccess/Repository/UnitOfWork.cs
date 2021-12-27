using CarCollection.DataAccess.Data;
using CarCollection.DataAccess.Repository.IRepository;
using CarCollection.Models.Models;
using FoodDelivery.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCollection.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICarRepository Car { get; private set; }
        public IInvoiceRepository Invoice { get; private set; }
        public IReviewRepository Review { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IReviewListRepository ReviewList { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Car = new CarRepository(_db);
            Invoice = new InvoiceRepository(_db);
            Review = new ReviewRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
