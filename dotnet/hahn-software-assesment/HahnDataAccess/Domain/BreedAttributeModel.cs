using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HahnDataAccess.Domain.Base;
using HahnDomain;
using Microsoft.EntityFrameworkCore;

namespace HahnDataAccess.Domain;

[Table("BreedAttributeBoolean"), PrimaryKey(nameof(Id), nameof(_AttributeType))]
public class BreedAttributeBooleanModel : KeylessModel, IBreedAttributeBoolean
{
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Key, Column("AttributeType", Order = 1)]
    private long _AttributeType { get; set; }

    [NotMapped]
    public virtual BreedAttributesType AttributeType
    {
        get
        {
            return (BreedAttributesType)_AttributeType;
        }

        set
        {
            _AttributeType = (long)value;
        }
    }

    public bool Value { get; set; }

}

[Table("BreedAttributeRange"), PrimaryKey(nameof(Id), nameof(_AttributeType))]
public class BreedAttributeRangeModel : KeylessModel, IBreedAttributesRange
{
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Key, Column("AttributeType", Order = 1)]
    private long _AttributeType { get; set; }

    [NotMapped]
    public virtual BreedAttributesType AttributeType
    {
        get
        {
            return (BreedAttributesType)_AttributeType;
        }

        set
        {
            _AttributeType = (long)value;
        }
    }

    public decimal Min { get; set; }
    public decimal Max { get; set; }
}
