using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Location GetLocationByCode(string lc)
        {
            return _dbContext
                .Locations
                .SingleOrDefault(i => i.Code == lc);
        }

        public string GetLocationById(int id)
        {
            var location = _dbContext
                .Locations
                .SingleOrDefault(i => i.Id == id);
            return location.Name;
        }

        public IEnumerable<SelectListItem> GetDropDown(IUnitOfWork unitOfWork)
        {
            List<SelectListItem> locations = unitOfWork.Locations.GetAll()
               .OrderBy(n => n.Name)
                   .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Id.ToString(),
                       Text = n.Name
                   }).ToList();
            var defaultLocation = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Location ---"
            };
            locations.Insert(0, defaultLocation);
            return new SelectList(locations, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetLocationFeeDropDown(IUnitOfWork unitOfWork)
        {
            var locations = unitOfWork.Locations.GetAll();
            var fee = unitOfWork.Fees.GetAll();

            List<SelectListItem> ddLocations = locations
                .Join(fee, l => l.Id, f => f.LocationId, ((l, f)
                => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                })).ToList();

            var defaultLocation = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Location ---"
            };
            ddLocations.Insert(0, defaultLocation);
            return new SelectList(ddLocations, "Value", "Text");
        }
    }
}
