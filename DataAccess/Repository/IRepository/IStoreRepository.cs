using System.Linq;
using CarCollection.Models;

namespace CarCollection.Models {
    public interface IStoreRepository {

        IQueryable<Review> Reviews { get; }
    }
}
