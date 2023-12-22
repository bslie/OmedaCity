using Newtonsoft.Json;

namespace OmedaCity.Models;

public class Flag
{
    [JsonProperty("identifier")]
    public string? Identifier;

    [JsonProperty("text")]
    public string? Text;

    [JsonProperty("color")]
    public string? Color;
}