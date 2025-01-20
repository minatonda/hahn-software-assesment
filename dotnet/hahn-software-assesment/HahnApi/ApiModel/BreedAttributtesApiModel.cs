using HahnDomain;

namespace HahnApi.ApiModel;

public class BreedAttributeApiModel<T>
{
    public BreedAttributesType AttributeType { get; set; }
    public T Value { get; set; }

}

public class BreedAttributeRange
{
    public decimal Min { get; set; }
    public decimal Max { get; set; }

}