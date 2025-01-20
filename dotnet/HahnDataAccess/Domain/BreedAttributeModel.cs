using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HahnDataAccess.Domain.Base;
using HahnDomain;
using Microsoft.EntityFrameworkCore;

namespace HahnDataAccess.Domain;

[Table("BreedAttributeBoolean"), PrimaryKey(nameof(Id), nameof(AttributeType))]
public class BreedAttributeBooleanModel : KeylessModel, IBreedAttributeBoolean
{
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Key, Column(Order = 1)]
    public BreedAttributesType AttributeType { get; set; }

    public bool Value { get; set; }
    
}

[Table("BreedAttributeRange"), PrimaryKey(nameof(Id), nameof(AttributeType))]
public class BreedAttributeRangeModel : KeylessModel, IBreedAttributesRange
{
    [Key, Column(Order = 0)]
    public string Id { get; set; }

    [Key, Column(Order = 1)]
    public BreedAttributesType AttributeType { get; set; }

    public decimal Min { get; set; }
    public decimal Max { get; set; }
}
