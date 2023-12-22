using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Player
{
    [JsonProperty("id")]
    public string? Id;

    [JsonProperty("display_name")]
    public string? DisplayName;

    [JsonProperty("region")]
    public string? Region;

    [JsonProperty("rank")]
    public int? Rank;

    [JsonProperty("rank_active")]
    public int? RankActive;

    [JsonProperty("is_active")]
    public bool? IsActive;

    [JsonProperty("rank_title")]
    public string? RankTitle;

    [JsonProperty("rank_image")]
    public string? RankImage;

    [JsonProperty("is_ranked")]
    public bool? IsRanked;

    [JsonProperty("mmr")]
    public double? Mmr;

    [JsonProperty("flags")]
    public List<Flag>? Flags;
}

