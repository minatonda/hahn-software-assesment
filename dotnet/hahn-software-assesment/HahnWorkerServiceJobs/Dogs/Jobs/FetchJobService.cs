namespace HahnWorkerServiceJobs.Dogs.Jobs;

using System.Net.Http.Json;
using System.Threading.Tasks;
using DataAccess.Repository;
using HahnDataAccess;
using HahnDataAccess.Domain;
using HahnDomain;
using HahnWorkerServiceJobs.Dogs.Domain;
using Microsoft.EntityFrameworkCore;

public class FetchJobService
{
    private ApplicationContext _applicationContext;
    private BreedRepository _breedRepository;
    private HttpClient _httpClient;
    private BreedAttributeBooleanRepository _breedAttributeCommonRepository;
    private BreedAttributeRangeRepository _breedAttributeRangeRepository;

    public FetchJobService(
        ApplicationContext applicationContext,
        HttpClient httpClient,
        BreedRepository breedRepository,
        BreedAttributeBooleanRepository breedAttributeBooleanRepository,
        BreedAttributeRangeRepository breedAttributeRangeRepository
    )
    {
        this._applicationContext = applicationContext;
        this._httpClient = httpClient;
        this._breedRepository = breedRepository;
        this._breedAttributeCommonRepository = breedAttributeBooleanRepository;
        this._breedAttributeRangeRepository = breedAttributeRangeRepository;
    }
    public async Task FetchData()
    {
        await Task.WhenAll(FetchBreeds());
    }

    public async Task FetchBreeds()
    {
        using var response = await _httpClient.GetAsync("breeds");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<ApiResponse<ApiBreed[]>>();

        var lBreeds = new List<BreedModel>();
        var lBreedAttributesBoolean = new List<BreedAttributeBooleanModel>();
        var lBreedAttributesRanges = new List<BreedAttributeRangeModel>();

        foreach (var apiBreed in json.data)
        {
            lBreeds.Add(new BreedModel()
            {
                Id = apiBreed.id,
                Name = apiBreed.attributes.name,
                Description = apiBreed.attributes.description
            });


            lBreedAttributesBoolean.Add(new BreedAttributeBooleanModel()
            {
                Id = apiBreed.id,
                AttributeType=BreedAttributesType.HYPOALLERGENIC,
                Value = apiBreed.attributes.hypoallergenic
            });

            lBreedAttributesRanges.AddRange([
                new BreedAttributeRangeModel(){
                    Id=apiBreed.id,
                    AttributeType=BreedAttributesType.LIFE,
                    Min = apiBreed.attributes.life.min,
                    Max = apiBreed.attributes.life.max
                },
                new BreedAttributeRangeModel(){
                    Id=apiBreed.id,
                    AttributeType=BreedAttributesType.MALE_WEIGHT,
                    Min = apiBreed.attributes.male_weight.min,
                    Max = apiBreed.attributes.male_weight.max
                },
                new BreedAttributeRangeModel(){
                    Id=apiBreed.id,
                    AttributeType=BreedAttributesType.FEMALE_WEIGHT,
                    Min = apiBreed.attributes.female_weight.min,
                    Max = apiBreed.attributes.female_weight.max
                }]
            );
        };

        using (var transaction = this._applicationContext.Database.BeginTransaction())
        {
            this._applicationContext.Database.ExecuteSqlRaw("DELETE FROM Breed");
            this._applicationContext.Database.ExecuteSqlRaw("DELETE FROM BreedAttributeBoolean");
            this._applicationContext.Database.ExecuteSqlRaw("DELETE FROM BreedAttributeRange");
            this._breedRepository.AddRange(lBreeds);
            this._breedAttributeCommonRepository.AddRange(lBreedAttributesBoolean);
            this._breedAttributeRangeRepository.AddRange(lBreedAttributesRanges);
            this._applicationContext.SaveChanges();
            transaction.Commit();
        }

    }
}
