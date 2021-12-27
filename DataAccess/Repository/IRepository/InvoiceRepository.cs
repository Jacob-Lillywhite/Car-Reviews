using CarCollection.DataAccess.Data;
using CarCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCollection.DataAccess.Repository.IRepository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;
        public InvoiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetInvoiceListForDropDown()
        {
            return _db.Invoice.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString()
            });
        }

        public void Update(CarCollection.Models.Invoice invoice)
        {
            var objFromDb = _db.Invoice.FirstOrDefault(s => s.Id == invoice.Id);
            objFromDb.ApplicationUserId = invoice.ApplicationUserId;
            objFromDb.CarId = invoice.CarId;
            objFromDb.Date = invoice.Date;
            objFromDb.Quantity = invoice.Quantity;
            objFromDb.Value = invoice.Value;

            _db.SaveChanges();
        }
    }
}
