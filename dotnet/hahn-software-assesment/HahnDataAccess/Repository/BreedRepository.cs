using DataAccess.Repository.Base;
using HahnDataAccess;
using HahnDataAccess.Domain;
using HahnDomain;

namespace DataAccess.Repository
{
    public class BreedRepository : KeylessGenericRepository<BreedModel>
    {
        public BreedRepository(ApplicationContext context) : base(context)
        {
        }
    }
}