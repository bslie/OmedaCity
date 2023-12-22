using Newtonsoft.Json;

namespace OmedaCity.Models;

public class HeroStatistic
{
    [JsonProperty("hero_id")]
    public int? HeroId;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("match_count")]
    public double? MatchCount;

    [JsonProperty("winrate")]
    public double? WinRate;

    [JsonProperty("pickrate")]
    public double? PickRate;

    [JsonProperty("kills")]
    public int? Kills;

    [JsonProperty("deaths")]
    public int? Deaths;

    [JsonProperty("assists")]
    public int? Assists;

    [JsonProperty("avg_kdar")]
    public double? AvgKdar;

    [JsonProperty("avg_cs")]
    public double? AvgCs;

    [JsonProperty("avg_gold")]
    public double? AvgGold;

    [JsonProperty("avg_performance_score")]
    public double? AvgPerformanceScore;

    [JsonProperty("avg_damage_dealt_to_heroes")]
    public double? AvgDamageDealtToHeroes;

    [JsonProperty("avg_damage_taken_from_heroes")]
    public double? AvgDamageTakenFromHeroes;

    [JsonProperty("avg_game_duration")]
    public double? AvgGameDuration;
}

public class HeroStatisticsModel
{
    [JsonProperty("hero_statistics")]
    public List<HeroStatistic>? HeroStatistics;
}

