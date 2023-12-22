
using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Build
{
    [JsonProperty("id")]
    public int? Id;

    [JsonProperty("title")]
    public string? Title;

    [JsonProperty("description")]
    public string? Description;

    [JsonProperty("hero_id")]
    public int? HeroId;

    [JsonProperty("crest_id")]
    public int? CrestId;

    [JsonProperty("item1_id")]
    public int? Item1Id;

    [JsonProperty("item2_id")]
    public int? Item2Id;

    [JsonProperty("item3_id")]
    public int? Item3Id;

    [JsonProperty("item4_id")]
    public int? Item4Id;

    [JsonProperty("item5_id")]
    public int? Item5Id;

    [JsonProperty("created_at")]
    public DateTime? CreatedAt;

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt;

    [JsonProperty("url")]
    public string? Url;
}