using HahnDomain.Domain.Base;

namespace HahnDomain;

public interface IBreed : KeylessDomain
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}