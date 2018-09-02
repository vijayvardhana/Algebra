using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Mapster;
using System.Linq;

namespace Algebra.Data.Repositories
{
    public class FeeRepository : Repository<Fee>, IFeeRepository
    {
        public FeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public FeeViewModels CreateFee(int id)
        {
            var fee = new FeeViewModels();

            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                var model = unitOfWork.Fees.Get(id);
                if (model != null)
                {
                    fee = model.Adapt<FeeViewModels>();
                }
                fee.Locations = unitOfWork.Locations.GetDropDown(unitOfWork);
            };

            return fee;
        }

        Fee IFeeRepository.GetFeeByLocationId(int locationId)
        {
            var f = new Fee();
            using(var unitOfWork = new UnitOfWork(_dbContext))
            {
                f = unitOfWork.Fees.GetAll()
                    .SingleOrDefault(l => l.LocationId == locationId);
            }
            return f;
        }
    }
}
