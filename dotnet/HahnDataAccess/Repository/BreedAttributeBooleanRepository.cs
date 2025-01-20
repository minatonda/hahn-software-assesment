using DataAccess.Repository.Base;
using HahnDataAccess;
using HahnDataAccess.Domain;
using HahnDomain;

namespace DataAccess.Repository
{
    public class BreedAttributeBooleanRepository : KeylessGenericRepository<BreedAttributeBooleanModel>
    {
        public BreedAttributeBooleanRepository(ApplicationContext context) : base(context)
        {
        }
    }
}