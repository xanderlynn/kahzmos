using Newtonsoft.Json;

namespace SpaceExplorer.Models;

public record Mission
{
    [JsonProperty("id")]
    public string Id { get; init; } = default!;

    [JsonProperty("name")]
    public string Name { get; init; } = default!;

    [JsonProperty("agency")]
    public string Agency { get; init; } = default!;

    [JsonProperty("launchYear")]
    public int LaunchYear { get; init; }

    [JsonProperty("destination")]
    public string Destination { get; init; } = default!;

    [JsonProperty("status")]
    public string Status { get; init; } = default!;

    [JsonProperty("objective")]
    public string Objective { get; init; } = default!;

    [JsonProperty("crewed")]
    public bool Crewed { get; init; }

    [JsonProperty("notableAchievement")]
    public string NotableAchievement { get; init; } = default!;
}
