using System.ComponentModel;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using OmedaCity.Enums;
using OmedaCity.Models;

namespace OmedaCity;

public static class OmedaCityClientApi
{
    public const string BaseUrl = "https://omeda.city/";

    public static async Task<List<Build>> GetBuilds()
    {
        var buildsJson = await BaseUrl
            .AppendPathSegment("builds.json")
            .GetAsync()
            .ReceiveString();

        return JsonConvert.DeserializeObject<List<Build>>(buildsJson) ?? throw new InvalidOperationException();
    }

    public static async Task<Build> GetBuildById(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

        var buildJson = await BaseUrl
            .AppendPathSegment("builds")
            .AppendPathSegment($"{id}.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<Build>(buildJson) ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics()
    {
        var buildJson = await BaseUrl
            .AppendPathSegments("dashboard", "hero_statistics.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<HeroStatisticsModel>(buildJson) ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics(int[] heroIds, TimeFrame timeFrame)
    {
        if (heroIds.Length < 1) throw new ArgumentOutOfRangeException(nameof(heroIds));

        if (!Enum.IsDefined(typeof(TimeFrame), timeFrame))
            throw new InvalidEnumArgumentException(nameof(timeFrame), (int)timeFrame, typeof(TimeFrame));

        var idsString = "[" + string.Join(", ", heroIds) + "]";

        var buildJson = await BaseUrl
            .AppendPathSegments("dashboard", "hero_statistics.json")
            .SetQueryParam("hero_ids", idsString)
            .SetQueryParam("time_frame", timeFrame.ToStringValue())
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<HeroStatisticsModel>(buildJson) ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics(int[] heroIds)
    {
        if (heroIds.Length <= 0) throw new ArgumentOutOfRangeException(nameof(heroIds));

        var idsString = "[" + string.Join(", ", heroIds) + "]";

        var buildJson = await BaseUrl
            .AppendPathSegments("dashboard", "hero_statistics.json")
            .SetQueryParam("hero_ids", idsString)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<HeroStatisticsModel>(buildJson) ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics(TimeFrame timeFrame)
    {
        if (!Enum.IsDefined(typeof(TimeFrame), timeFrame))
            throw new InvalidEnumArgumentException(nameof(timeFrame), (int)timeFrame, typeof(TimeFrame));

        var buildJson = await BaseUrl
            .AppendPathSegments("dashboard", "hero_statistics.json")
            .SetQueryParam("time_frame", timeFrame.ToStringValue())
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<HeroStatisticsModel>(buildJson) ?? throw new InvalidOperationException();
    }

    public static async Task<List<Hero>> GetHeroes()
    {
        var heroesJson = await BaseUrl
            .AppendPathSegment("heroes.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Hero>>(heroesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<Hero> GetHeroByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var heroJson = await BaseUrl
            .AppendPathSegment("heroes")
            .AppendPathSegment($"{name}.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<Hero>(heroJson) ?? throw new InvalidOperationException();
    }

    public static async Task<List<Item>> GetItems()
    {
        var itemsJson = await BaseUrl
            .AppendPathSegment("items.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Item>>(itemsJson) ?? throw new InvalidOperationException();
    }

    public static async Task<Item> GetItemByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var itemJson = await BaseUrl
            .AppendPathSegment("items")
            .AppendPathSegment($"{name}.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<Item>(itemJson) ?? throw new InvalidOperationException();
    }

    public static async Task<MatchesModel> GetMatches(long timestamp, int matchesPerPage = 10)
    {
        if (timestamp <= 0) throw new ArgumentOutOfRangeException(nameof(timestamp));

        var matchesJson = await BaseUrl
            .AppendPathSegment("matches.json")
            .SetQueryParam("timestamp", timestamp)
            .SetQueryParam("matches_per_page", $"{matchesPerPage}")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<MatchesModel>(matchesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<MatchesModel> GetMatches(DateTime dateTime, int matchesPerPage = 10)
    {
        var matchesJson = await BaseUrl
            .AppendPathSegment("matches.json")
            .SetQueryParam("timestamp", ((DateTimeOffset)dateTime).ToUnixTimeSeconds())
            .SetQueryParam("matches_per_page", $"{matchesPerPage}")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<MatchesModel>(matchesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<MatchesModel> GetMatches(string cursor, int matchesPerPage = 10)
    {
        if (string.IsNullOrWhiteSpace(cursor))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(cursor));

        var matchesJson = await BaseUrl
            .AppendPathSegment("matches.json")
            .SetQueryParam("cursor", cursor)
            .SetQueryParam("matches_per_page", $"{matchesPerPage}")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<MatchesModel>(matchesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<Match> GetMatchById(string matchId)
    {
        if (string.IsNullOrWhiteSpace(matchId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(matchId));

        var matchJson = await BaseUrl
            .AppendPathSegment("matches")
            .AppendPathSegment($"{matchId}.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<Match>(matchJson) ?? throw new InvalidOperationException();
    }

    public static async Task<List<Player>> GetPlayers(int page = 1)
    {
        var playersJson = await BaseUrl
            .AppendPathSegment("players.json")
            .SetQueryParam("page", page)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Player>>(playersJson) ?? throw new InvalidOperationException();
    }

    public static async Task<List<Player>> GetPlayers(string name, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var playersJson = await BaseUrl
            .AppendPathSegment("players.json")
            .SetQueryParam("q[name]", name)
            .SetQueryParam("page", page)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Player>>(playersJson) ?? throw new InvalidOperationException();
    }

    public static async Task<Player> GetPlayerById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        var playersJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{id}.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<Player>(playersJson) ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerMatches> GetPlayerMatches(string playerId, string? timeFrame = null,
        int? page = null, int? matchesPerPage = null, int? heroId = null, string? role = null,
        int? occurringHeroId = null, string? playerName = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var matchesJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{playerId}/matches.json")
            .SetQueryParam("page", page)
            .SetQueryParam("matches_per_page", matchesPerPage)
            .SetQueryParam("time_frame", timeFrame)
            .SetQueryParam("match_filter[hero_id]", heroId)
            .SetQueryParam("match_filter[role]", role)
            .SetQueryParam("match_filter[occuring_hero_id]", occurringHeroId)
            .SetQueryParam("match_filter[player_name]", playerName)
            .GetAsync()
            .ReceiveString();

        return JsonConvert.DeserializeObject<PlayerMatches>(matchesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerMatches> GetPlayerMatches(string playerId, TimeFrame? timeFrame = null,
        int? page = null, int? matchesPerPage = null, int? heroId = null, Role? role = null,
        int? occurringHeroId = null, string? playerName = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var matchesJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{playerId}/matches.json")
            .SetQueryParam("page", page)
            .SetQueryParam("matches_per_page", matchesPerPage)
            .SetQueryParam("time_frame", timeFrame?.ToStringValue())
            .SetQueryParam("match_filter[hero_id]", heroId)
            .SetQueryParam("match_filter[role]", role?.ToStringValue())
            .SetQueryParam("match_filter[occuring_hero_id]", occurringHeroId)
            .SetQueryParam("match_filter[player_name]", playerName)
            .GetAsync()
            .ReceiveString();

        return JsonConvert.DeserializeObject<PlayerMatches>(matchesJson) ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerStatistics> GetPlayerStatistics(string playerId, TimeFrame? timeFrame = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var statisticsJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{playerId}")
            .AppendPathSegment("statistics.json")
            .SetQueryParam("time_frame", timeFrame?.ToStringValue())
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<PlayerStatistics>(statisticsJson) ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerHeroStatistics> GetPlayerHeroStatistics(string playerId, int[] heroIds)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        if (heroIds.Length < 1) throw new ArgumentOutOfRangeException(nameof(heroIds));

        var idsString = "[" + string.Join(", ", heroIds) + "]";

        var statisticsJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{playerId}")
            .AppendPathSegment("hero_statistics.json")
            .SetQueryParam("hero_ids", idsString)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<PlayerHeroStatistics>(statisticsJson) ?? throw new InvalidOperationException();
    }

    public static async Task<TeammatesModel> GetPlayerTeammates(string playerId, TimeFrame timeFrame = TimeFrame.All, int count = 10)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var teammatesJson = await BaseUrl
            .AppendPathSegment("players")
            .AppendPathSegment($"{playerId}")
            .AppendPathSegment("common_teammates.json")
            .SetQueryParam("time_frame", timeFrame.ToStringValue())
            .SetQueryParam("count", count)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<TeammatesModel>(teammatesJson) ?? throw new InvalidOperationException();
    }
}