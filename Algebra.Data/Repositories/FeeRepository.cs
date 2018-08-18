using Algebra.Entities.Models;
using Algebra.Entities.ViewModels;
using Mapster;

namespace Algebra.Data.Repositories
{
    public class FeeRepository : Repository<Fee>, IFeeRepository
    {
        public FeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        FeeViewModels IFeeRepository.CreateFee(int id)
        {
            var fee = new FeeViewModels();

            using(var unitOfWork = new UnitOfWork(_dbContext)) {
                var model = unitOfWork.Fees.Get(id);//.Adapt<MembershipFeeViewModels>();
                if(model != null)
                {
                    fee = model.Adapt<FeeViewModels>();
                    fee.Locations = unitOfWork.Locations.GetDropDown();
                }
                else
                {
                    fee.Locations = unitOfWork.Locations.GetDropDown();
                }
            };
               
            return fee;
        }
    }
}
