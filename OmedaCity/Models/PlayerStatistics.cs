using Newtonsoft.Json;

namespace OmedaCity.Models;
public class FavoriteHero
{
    [JsonProperty("id")]
    public int? Id;

    [JsonProperty("game_id")]
    public int? GameId;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("image")]
    public string? Image;

    [JsonProperty("stats")]
    public List<int>? Stats;

    [JsonProperty("classes")]
    public List<string>? Classes;

    [JsonProperty("roles")]
    public List<string>? Roles;

    [JsonProperty("visible")]
    public bool? Visible;

    [JsonProperty("enabled")]
    public bool? Enabled;

    [JsonProperty("created_at")]
    public DateTime? CreatedAt;

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt;
}

public class PlayerStatistics
{
    [JsonProperty("matches_played")]
    public int? MatchesPlayed;

    [JsonProperty("hours_played")]
    public double? HoursPlayed;

    [JsonProperty("avg_performance_score")]
    public double? AvgPerformanceScore;

    [JsonProperty("avg_kda")]
    public List<double>? AvgKda;

    [JsonProperty("avg_kdar")]
    public double? AvgKdar;

    [JsonProperty("favorite_hero")]
    public FavoriteHero? FavoriteHero;

    [JsonProperty("favorite_role")]
    public string? FavoriteRole;

    [JsonProperty("win_rate")]
    public double? WinRate;
}

