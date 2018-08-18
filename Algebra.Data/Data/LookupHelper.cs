using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data
{
    public static class LookupHelper
    {
        public static IEnumerable<Location> GetLocations(ApplicationDbContext _dbContext)
        {
            IEnumerable<Location> locations = null;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                locations = unitOfWork.Locations.GetAll().ToList();
            }
            return locations;

        }

        public static IEnumerable<Referrer> GetReferrers(ApplicationDbContext _dbContext)
        {
            IEnumerable<Referrer> referrer;
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                referrer = unitOfWork.Referrers.GetAll().ToList();
            }

            return referrer;
        }

        public static IEnumerable<Mode> GetPaymentModes(ApplicationDbContext _dbContext)
        {
            //IEnumerable<PaymentMode> paymentModes;
            //using (var unitOfWork = new UnitOfWork(_dbContext))
            //{
            //    //unitOfWork
            //}
            return null;
        }
    }
}
