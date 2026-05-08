using Newtonsoft.Json;

namespace SpaceExplorer.Models;

public record Planet
{
    [JsonProperty("id")]
    public string Id { get; init; } = default!;

    [JsonProperty("name")]
    public string Name { get; init; } = default!;

    [JsonProperty("type")]
    public string Type { get; init; } = default!;

    [JsonProperty("distanceFromSunAu")]
    public double DistanceFromSunAu { get; init; }

    [JsonProperty("diameterKm")]
    public double DiameterKm { get; init; }

    [JsonProperty("moons")]
    public int Moons { get; init; }

    [JsonProperty("hasRings")]
    public bool HasRings { get; init; }

    [JsonProperty("atmosphereComposition")]
    public List<string> AtmosphereComposition { get; init; } = [];

    [JsonProperty("funFact")]
    public string FunFact { get; init; } = default!;
}
