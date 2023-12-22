using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Match
{
    [JsonProperty("id")]
    public string? Id;

    [JsonProperty("start_time")]
    public DateTime? StartTime;

    [JsonProperty("end_time")]
    public DateTime? EndTime;

    [JsonProperty("game_duration")]
    public int? GameDuration;

    [JsonProperty("game_region")]
    public string? GameRegion;

    [JsonProperty("region")]
    public string? Region;

    [JsonProperty("winning_team")]
    public string? WinningTeam;

    [JsonProperty("game_mode")]
    public string? GameMode;

    [JsonProperty("players")]
    public List<PlayerMatch>? Players;
}

public class PlayerMatch
{
    [JsonProperty("id")]
    public string? Id;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("is_ranked")]
    public bool? IsRanked;

    [JsonProperty("mmr")]
    public double? Mmr;

    [JsonProperty("mmr_change")]
    public double? MmrChange;

    [JsonProperty("rank")]
    public string? Rank;

    [JsonProperty("rank_image")]
    public string? RankImage;

    [JsonProperty("flags")]
    public List<Flag>? Flags;

    [JsonProperty("team")]
    public string? Team;

    [JsonProperty("hero_id")]
    public int? HeroId;

    [JsonProperty("role")]
    public string? Role;

    [JsonProperty("minions_killed")]
    public int? MinionsKilled;

    [JsonProperty("lane_minions_killed")]
    public int? LaneMinionsKilled;

    [JsonProperty("neutral_minions_killed")]
    public int? NeutralMinionsKilled;

    [JsonProperty("neutral_minions_team_jungle")]
    public int? NeutralMinionsTeamJungle;

    [JsonProperty("neutral_minions_enemy_jungle")]
    public int? NeutralMinionsEnemyJungle;

    [JsonProperty("kills")]
    public int? Kills;

    [JsonProperty("deaths")]
    public int? Deaths;

    [JsonProperty("assists")]
    public int? Assists;

    [JsonProperty("largest_killing_spree")]
    public int? LargestKillingSpree;

    [JsonProperty("largest_multi_kill")]
    public int? LargestMultiKill;

    [JsonProperty("total_damage_dealt")]
    public int? TotalDamageDealt;

    [JsonProperty("physical_damage_dealt")]
    public int? PhysicalDamageDealt;

    [JsonProperty("magical_damage_dealt")]
    public int? MagicalDamageDealt;

    [JsonProperty("true_damage_dealt")]
    public int? TrueDamageDealt;

    [JsonProperty("largest_critical_strike")]
    public int? LargestCriticalStrike;

    [JsonProperty("total_damage_dealt_to_heroes")]
    public int? TotalDamageDealtToHeroes;

    [JsonProperty("physical_damage_dealt_to_heroes")]
    public int? PhysicalDamageDealtToHeroes;

    [JsonProperty("magical_damage_dealt_to_heroes")]
    public int? MagicalDamageDealtToHeroes;

    [JsonProperty("true_damage_dealt_to_heroes")]
    public int? TrueDamageDealtToHeroes;

    [JsonProperty("total_damage_dealt_to_structures")]
    public int? TotalDamageDealtToStructures;

    [JsonProperty("total_damage_dealt_to_objectives")]
    public int? TotalDamageDealtToObjectives;

    [JsonProperty("total_damage_taken")]
    public int? TotalDamageTaken;

    [JsonProperty("physical_damage_taken")]
    public int? PhysicalDamageTaken;

    [JsonProperty("magical_damage_taken")]
    public int? MagicalDamageTaken;

    [JsonProperty("true_damage_taken")]
    public int? TrueDamageTaken;

    [JsonProperty("total_damage_taken_from_heroes")]
    public int? TotalDamageTakenFromHeroes;

    [JsonProperty("physical_damage_taken_from_heroes")]
    public int? PhysicalDamageTakenFromHeroes;

    [JsonProperty("magical_damage_taken_from_heroes")]
    public int? MagicalDamageTakenFromHeroes;

    [JsonProperty("true_damage_taken_from_heroes")]
    public int? TrueDamageTakenFromHeroes;

    [JsonProperty("total_damage_mitigated")]
    public int? TotalDamageMitigated;

    [JsonProperty("total_healing_done")]
    public int? TotalHealingDone;

    [JsonProperty("item_healing_done")]
    public int? ItemHealingDone;

    [JsonProperty("crest_healing_done")]
    public int? CrestHealingDone;

    [JsonProperty("utility_healing_done")]
    public int? UtilityHealingDone;

    [JsonProperty("total_shielding_received")]
    public int? TotalShieldingReceived;

    [JsonProperty("wards_placed")]
    public int? WardsPlaced;

    [JsonProperty("wards_destroyed")]
    public int? WardsDestroyed;

    [JsonProperty("gold_earned")]
    public int? GoldEarned;

    [JsonProperty("gold_spent")]
    public int? GoldSpent;

    [JsonProperty("inventory_data")]
    public List<int>? InventoryData;

    [JsonProperty("performance_score")]
    public double? PerformanceScore;

    [JsonProperty("performance_title")]
    public string? PerformanceTitle;

    [JsonProperty("rating_deviation_change")]
    public object? RatingDeviationChange;

    [JsonProperty("skill")]
    public double? Skill;

    [JsonProperty("skill_change")]
    public double? SkillChange;

    [JsonProperty("skill_uncertainty_change")]
    public double? SkillUncertaintyChange;

    [JsonProperty("level")]
    public int? Level;
}

public class MatchesModel
{
    [JsonProperty("matches")]
    public List<Match>? Matches;

    [JsonProperty("cursor")]
    public string? Cursor;
}

