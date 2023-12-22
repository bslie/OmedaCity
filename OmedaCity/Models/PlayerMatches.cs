using Newtonsoft.Json;

namespace OmedaCity.Models;

public class PlayerMatches
{
    [JsonProperty("matches")]
    public List<Match>? Matches;
}

