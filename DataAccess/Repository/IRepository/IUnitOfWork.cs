using CarCollection.DataAccess.Repository.IRepository;
using FoodDelivery.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Car { get; }
        IInvoiceRepository Invoice { get; }
        IReviewRepository Review { get; }
       IApplicationUserRepository ApplicationUser { get; }
        IReviewListRepository ReviewList { get; }

        void Save();
    }
}
