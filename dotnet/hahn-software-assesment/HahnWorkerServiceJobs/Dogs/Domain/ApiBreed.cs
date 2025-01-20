namespace HahnWorkerServiceJobs.Dogs.Domain;

public class ApiBreed : ApiBase
{
    public ApiBreedAttributes attributes { get; set; }
}

public class ApiBreedAttributes
{
    public string name { get; set; }
    public string description { get; set; }
    public ApiBreedAttributesRange life { get; set; }
    public ApiBreedAttributesRange male_weight { get; set; }
    public ApiBreedAttributesRange female_weight { get; set; }
    public bool hypoallergenic { get; set; }
}

public class ApiBreedAttributesRange
{
    public int max { get; set; }
    public int min { get; set; }
}

public class ApiBreedAttributesRelationship
{
    public int max { get; set; }
    public int min { get; set; }
}

public class ApiBreedAttributesRelationshipGroup
{
    public ApiBase data { get; set; }
}