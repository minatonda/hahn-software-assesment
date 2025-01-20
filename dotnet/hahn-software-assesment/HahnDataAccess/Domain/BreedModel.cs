using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HahnDataAccess.Domain.Base;
using HahnDomain;

namespace HahnDataAccess.Domain;

[Table("Breed")]
public class BreedModel : KeylessModel, IBreed
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}