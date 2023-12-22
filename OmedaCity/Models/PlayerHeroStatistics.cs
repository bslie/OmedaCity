using Newtonsoft.Json;

namespace OmedaCity.Models;

public class HeroStatistics
{
    [JsonProperty("hero_id")]
    public int? HeroId;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("match_count")]
    public int? MatchCount;

    [JsonProperty("win_rate")]
    public double? WinRate;

    [JsonProperty("cs_min")]
    public double? CsMin;

    [JsonProperty("gold_min")]
    public double? GoldMin;

    [JsonProperty("largest_killing_spree")]
    public int? LargestKillingSpree;

    [JsonProperty("largest_multi_kill")]
    public int? LargestMultiKill;

    [JsonProperty("largest_critical_strike")]
    public int? LargestCriticalStrike;

    [JsonProperty("total_performance_score")]
    public double? TotalPerformanceScore;

    [JsonProperty("avg_performance_score")]
    public double? AvgPerformanceScore;

    [JsonProperty("max_performance_score")]
    public double? MaxPerformanceScore;

    [JsonProperty("kills")]
    public int? Kills;

    [JsonProperty("avg_kills")]
    public int? AvgKills;

    [JsonProperty("max_kills")]
    public int? MaxKills;

    [JsonProperty("deaths")]
    public int? Deaths;

    [JsonProperty("avg_deaths")]
    public int? AvgDeaths;

    [JsonProperty("max_deaths")]
    public int? MaxDeaths;

    [JsonProperty("assists")]
    public int? Assists;

    [JsonProperty("avg_assists")]
    public int? AvgAssists;

    [JsonProperty("max_assists")]
    public int? MaxAssists;

    [JsonProperty("avg_kdar")]
    public double? AvgKdar;

    [JsonProperty("max_kdar")]
    public double? MaxKdar;

    [JsonProperty("minions_killed")]
    public int? MinionsKilled;

    [JsonProperty("avg_minions_killed")]
    public int? AvgMinionsKilled;

    [JsonProperty("max_minions_killed")]
    public int? MaxMinionsKilled;

    [JsonProperty("gold_earned")]
    public int? GoldEarned;

    [JsonProperty("avg_gold_earned")]
    public int? AvgGoldEarned;

    [JsonProperty("max_gold_earned")]
    public int? MaxGoldEarned;

    [JsonProperty("total_healing_done")]
    public int? TotalHealingDone;

    [JsonProperty("avg_healing_done")]
    public int? AvgHealingDone;

    [JsonProperty("max_healing_done")]
    public int? MaxHealingDone;

    [JsonProperty("total_damage_mitigated")]
    public int? TotalDamageMitigated;

    [JsonProperty("avg_damage_mitigated")]
    public int? AvgDamageMitigated;

    [JsonProperty("max_damage_mitigated")]
    public int? MaxDamageMitigated;

    [JsonProperty("total_damage_dealt_to_heroes")]
    public int? TotalDamageDealtToHeroes;

    [JsonProperty("avg_damage_dealt_to_heroes")]
    public int? AvgDamageDealtToHeroes;

    [JsonProperty("max_damage_dealt_to_heroes")]
    public int? MaxDamageDealtToHeroes;

    [JsonProperty("total_damage_taken_from_heroes")]
    public int? TotalDamageTakenFromHeroes;

    [JsonProperty("avg_damage_taken_from_heroes")]
    public int? AvgDamageTakenFromHeroes;

    [JsonProperty("max_damage_taken_from_heroes")]
    public int? MaxDamageTakenFromHeroes;

    [JsonProperty("total_damage_dealt_to_structures")]
    public int? TotalDamageDealtToStructures;

    [JsonProperty("avg_damage_dealt_to_structures")]
    public int? AvgDamageDealtToStructures;

    [JsonProperty("max_damage_dealt_to_structures")]
    public int? MaxDamageDealtToStructures;

    [JsonProperty("total_damage_dealt_to_objectives")]
    public int? TotalDamageDealtToObjectives;

    [JsonProperty("avg_damage_dealt_to_objectives")]
    public int? AvgDamageDealtToObjectives;

    [JsonProperty("max_damage_dealt_to_objectives")]
    public int? MaxDamageDealtToObjectives;

    [JsonProperty("wards_placed")]
    public int? WardsPlaced;

    [JsonProperty("avg_wards_placed")]
    public int? AvgWardsPlaced;

    [JsonProperty("max_wards_placed")]
    public int? MaxWardsPlaced;

    [JsonProperty("wards_destroyed")]
    public int? WardsDestroyed;

    [JsonProperty("avg_wards_destroyed")]
    public int? AvgWardsDestroyed;

    [JsonProperty("max_wards_destroyed")]
    public int? MaxWardsDestroyed;
}

public class PlayerHeroStatistics
{
    [JsonProperty("hero_statistics")]
    public List<HeroStatistics>? HeroStatistics;
}

