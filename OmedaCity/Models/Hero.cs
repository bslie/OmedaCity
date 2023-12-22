using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Ability
{
    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("image")]
    public string? Image;

    [JsonProperty("game_description")]
    public string? GameDescription;

    [JsonProperty("menu_description")]
    public string? MenuDescription;

    [JsonProperty("cooldown")]
    public List<double>? Cooldown;

    [JsonProperty("cost")]
    public List<double>? Cost;
}

public class BaseStats
{
    [JsonProperty("max_health")]
    public List<double>? MaxHealth;

    [JsonProperty("base_health_regeneration")]
    public List<double>? BaseHealthRegeneration;

    [JsonProperty("max_mana")]
    public List<double>? MaxMana;

    [JsonProperty("base_mana_regeneration")]
    public List<double>? BaseManaRegeneration;

    [JsonProperty("attack_speed")]
    public List<double>? AttackSpeed;

    [JsonProperty("physical_armor")]
    public List<double>? PhysicalArmor;

    [JsonProperty("magical_armor")]
    public List<double>? MagicalArmor;

    [JsonProperty("basic_attack_time")]
    public List<double>? BasicAttackTime;

    [JsonProperty("physical_power")]
    public List<double>? PhysicalPower;

    [JsonProperty("base_movement_speed")]
    public List<double>? BaseMovementSpeed;

    [JsonProperty("cleave")]
    public List<double>? Cleave;

    [JsonProperty("attack_range")]
    public List<double>? AttackRange;
}

public class Hero
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

    [JsonProperty("abilities")]
    public List<Ability>? Abilities;

    [JsonProperty("base_stats")]
    public BaseStats? BaseStats;
}

