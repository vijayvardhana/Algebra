using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        Location ILocationRepository.GetLocationByCode(string lc)
        {
            return _dbContext.Locations.FirstOrDefault(i => i.Code == lc);
        }

        Dictionary<int, string> ILocationRepository.GetLocations()
        {
            Dictionary<int, string> loc = new Dictionary<int, string>();
            var locations = _dbContext.Locations;
            if (locations.Any())
            {
                foreach (var location in _dbContext.Locations)
                {
                    loc.Add(location.Id, location.Name);
                }
            }
            return loc;
        }

        public IEnumerable<SelectListItem> GetDropDown()
        {
            using(var unitOfWork = new UnitOfWork(_dbContext))
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
        }
    }
}
