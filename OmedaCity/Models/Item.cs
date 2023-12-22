using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Effect
{
    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("active")]
    public bool? Active;

    [JsonProperty("game_description")]
    public string? GameDescription;

    [JsonProperty("menu_description")]
    public string? MenuDescription;
}

public class Item
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

    [JsonProperty("price")]
    public int? Price;

    [JsonProperty("total_price")]
    public int? TotalPrice;

    [JsonProperty("slot_type")]
    public string? SlotType;

    [JsonProperty("rarity")]
    public string? Rarity;

    [JsonProperty("aggression_type")]
    public string? AggressionType;

    [JsonProperty("hero_class")]
    public string? HeroClass;

    [JsonProperty("required_level")]
    public int? RequiredLevel;

    [JsonProperty("effects")]
    public List<Effect>? Effects;

    [JsonProperty("requirements")]
    public List<string>? Requirements;

    [JsonProperty("build_paths")]
    public List<string>? BuildPaths;

    [JsonProperty("stats")]
    public Stats? Stats;
}

public class Stats
{
    [JsonProperty("max_health")]
    public double? MaxHealth;

    [JsonProperty("physical_armor")]
    public double? PhysicalArmor;

    [JsonProperty("magical_armor")]
    public double? MagicalArmor;

    [JsonProperty("health_regeneration")]
    public double? HealthRegeneration;

    [JsonProperty("gold_per_second")]
    public double? GoldPerSecond;

    [JsonProperty("magical_power")]
    public double? MagicalPower;

    [JsonProperty("mana_regeneration")]
    public double? ManaRegeneration;

    [JsonProperty("heal_shield_increase")]
    public double? HealShieldIncrease;

    [JsonProperty("ability_haste")]
    public double? AbilityHaste;

    [JsonProperty("max_mana")]
    public double? MaxMana;

    [JsonProperty("attack_speed")]
    public double? AttackSpeed;

    [JsonProperty("omnivamp")]
    public double? Omnivamp;

    [JsonProperty("magical_penetration")]
    public double? MagicalPenetration;

    [JsonProperty("physical_power")]
    public double? PhysicalPower;

    [JsonProperty("lifesteal")]
    public double? Lifesteal;

    [JsonProperty("physical_penetration")]
    public double? PhysicalPenetration;

    [JsonProperty("critical_chance")]
    public double? CriticalChance;

    [JsonProperty("tenacity")]
    public double? Tenacity;

    [JsonProperty("magical_lifesteal")]
    public double? MagicalLifesteal;

    [JsonProperty("movement_speed")]
    public double? MovementSpeed;
}

