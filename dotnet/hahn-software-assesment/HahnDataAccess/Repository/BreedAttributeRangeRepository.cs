using DataAccess.Repository.Base;
using HahnDataAccess;
using HahnDataAccess.Domain;
using HahnDomain;

namespace DataAccess.Repository
{
    public class BreedAttributeRangeRepository : KeylessGenericRepository<BreedAttributeRangeModel>
    {
        public BreedAttributeRangeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}