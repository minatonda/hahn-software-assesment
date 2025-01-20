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
    public BreedAttributesType AttributeType { get; set; }
    public bool Value { get; set; }
}

public enum BreedAttributesType : long
{
    [Description("LIFE")]
    LIFE = 0,

    [Description("MALE_WEIGHT")]
    MALE_WEIGHT = 1,

    [Description("FEMALE_WEIGHT")]
    FEMALE_WEIGHT = 2,

    [Description("HYPOALLERGENIC")]
    HYPOALLERGENIC = 3
}
