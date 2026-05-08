using Newtonsoft.Json;

namespace SpaceExplorer.Models;

public record Astronaut
{
    [JsonProperty("id")]
    public string Id { get; init; } = default!;

    [JsonProperty("name")]
    public string Name { get; init; } = default!;

    [JsonProperty("nationality")]
    public string Nationality { get; init; } = default!;

    [JsonProperty("agency")]
    public string Agency { get; init; } = default!;

    [JsonProperty("totalSpacewalkHours")]
    public double TotalSpacewalkHours { get; init; }

    [JsonProperty("missions")]
    public List<string> Missions { get; init; } = [];

    [JsonProperty("firstMissionYear")]
    public int FirstMissionYear { get; init; }

    [JsonProperty("funFact")]
    public string FunFact { get; init; } = default!;
}
