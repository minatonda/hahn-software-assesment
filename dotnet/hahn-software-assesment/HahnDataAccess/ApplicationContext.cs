using Microsoft.EntityFrameworkCore;
using HahnDomain;
using HahnDataAccess.Domain;

namespace HahnDataAccess;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<BreedModel> BreedSet { get; set; }
    public DbSet<BreedAttributeBooleanModel> BreedAttribute { get; set; }
    public DbSet<BreedAttributeRangeModel> BreedRange { get; set; }

}