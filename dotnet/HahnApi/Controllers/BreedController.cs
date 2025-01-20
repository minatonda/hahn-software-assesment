using DataAccess.Repository;
using HahnApi.ApiModel;
using Microsoft.AspNetCore.Mvc;

namespace HahnApi.Controllers;

[Route("api/breed")]
[ApiController]
public class BreedController : ControllerBase
{

    private BreedRepository _breedRepository;
    private BreedAttributeBooleanRepository _breedAttributeBooleanRepository;
    private BreedAttributeRangeRepository _breedAttributeRangeRepository;

    public BreedController(
        BreedRepository breedRepository,
        BreedAttributeBooleanRepository breedAttributeBooleanRepository,
        BreedAttributeRangeRepository breedAttributeRangeRepository
    )
    {
        this._breedRepository = breedRepository;
        this._breedAttributeBooleanRepository = breedAttributeBooleanRepository;
        this._breedAttributeRangeRepository = breedAttributeRangeRepository;

    }

    [HttpGet]
    public async Task<IEnumerable<BreedApiModel>> Get()
    {
        return _breedRepository
        .GetAll()
        .Select((x) => new BreedApiModel()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        });
    }

    [HttpGet("{id}/attributes")]
    public async Task<IEnumerable<BreedAttributeApiModel<object>>> GetAttributes([FromRoute] string id)
    {
        BreedAttributeApiModel<object>[] attributes = [];

        var booleanAttributes = _breedAttributeBooleanRepository
        .GetAll()
        .Where((x) => x.Id.Equals(id))
        .Select((x) => new BreedAttributeApiModel<object>()
        {
            AttributeType = x.AttributeType,
            Value = x.Value as object
        })
        .ToArray();

        var rangeAttributes = _breedAttributeRangeRepository
        .GetAll()
        .Where((x) => x.Id.Equals(id))
        .Select((x) => new BreedAttributeApiModel<object>()
        {
            AttributeType = x.AttributeType,
            Value = new BreedAttributeRange() { Max = x.Max, Min = x.Min }
        })
        .ToArray();

        if (booleanAttributes != null)
        {
            attributes =
            [
                .. attributes,
                .. booleanAttributes
            ];

        }

        if (rangeAttributes != null)
        {
            attributes =
            [
                .. attributes,
                .. rangeAttributes
            ];
        }

        return attributes;
    }

}