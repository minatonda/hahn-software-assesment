using System.ComponentModel;

namespace HahnDomain;

public interface IBreedAttributesRange
{
    public string Id { get; set; }
    public BreedAttributesType AttributeType { get; set; }
    public decimal Min { get; set; }
    public decimal Max { get; set; }
}

public interface IBreedAttributeBoolean
{
    public string Id { get; set; }
    public bool Value { get; set; }
}

public enum BreedAttributesType
{
    [Description("LIFE")]
    LIFE,

    [Description("MALE_WEIGHT")]
    MALE_WEIGHT,

    [Description("FEMALE_WEIGHT")]
    FEMALE_WEIGHT,
    
    [Description("HYPOALLERGENIC")]
    HYPOALLERGENIC
}
