using Newtonsoft.Json;

namespace OmedaCity.Models;

public class TeammatesModel
{
    [JsonProperty("teammates")]
    public List<Teammate>? Teammates;
}

public class Teammate
{
    [JsonProperty("id")]
    public string? Id;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("win_rate")]
    public double? WinRate;

    [JsonProperty("matches_played")]
    public int? MatchesPlayed;

    [JsonProperty("matches_percentage")]
    public double? MatchesPercentage;
}
