﻿using Endpoint.NET;
using OmedaCity.Enums;
using OmedaCity.Models;

namespace OmedaCity;

public class OmedaCityClientApi
{
    public const string BaseUrl = "https://omeda.city/";

    public static async Task<List<Build>> GetBuilds(int? page = null, int? heroId = null, Role? role = null,
        string? name = null, bool? skillOrder = null, bool? modules = null, bool? order = null)
    {
        var endpoint = new Endpoint<List<Build>>(BaseUrl);
        return await endpoint
                   .AppendPathSegment("builds.json")
                   .SetQueryParam("page", page)
                   .SetQueryParam("filter[hero_id]", heroId)
                   .SetQueryParam("filter[role]", role?.ToStringValue())
                   .SetQueryParam("filter[name]", name)
                   .SetQueryParam("filter[skill_order]", skillOrder)
                   .SetQueryParam("filter[modules]", modules)
                   .SetQueryParam("filter[order]", order)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }


    public static async Task<Build> GetBuildById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var endpoint = new Endpoint<Build>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("builds")
                   .AppendPathSegment($"{id}.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics()
    {
        var endpoint = new Endpoint<HeroStatisticsModel>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("dashboard")
                   .AppendPathSegment("hero_statistics.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<HeroStatisticsModel> GetHeroStatistics(int[] heroIds = null,
        TimeFrame timeFrame = TimeFrame.All)
    {
        var endpoint = new Endpoint<HeroStatisticsModel>(BaseUrl)
            .AppendPathSegment("dashboard")
            .AppendPathSegment("hero_statistics.json");

        if (heroIds is { Length: > 0 })
        {
            var idsString = "[" + string.Join(", ", heroIds) + "]";
            endpoint = endpoint.SetQueryParam("hero_ids", idsString);
        }

        if (timeFrame != TimeFrame.All) endpoint = endpoint.SetQueryParam("time_frame", timeFrame.ToStringValue());

        if (timeFrame == TimeFrame.All) endpoint = endpoint.SetQueryParam("time_frame", timeFrame.ToStringValue());

        return await endpoint.GetAsync() ?? throw new InvalidOperationException();
    }

    public static async Task<List<Hero>> GetHeroes()
    {
        var endpoint = new Endpoint<List<Hero>>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("heroes.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<Hero> GetHeroByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var endpoint = new Endpoint<Hero>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("heroes")
                   .AppendPathSegment($"{name}.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<List<Item>> GetItems()
    {
        var endpoint = new Endpoint<List<Item>>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("items.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<Item> GetItemByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var endpoint = new Endpoint<Item>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("items")
                   .AppendPathSegment($"{name}.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<MatchesModel> GetMatches(long timestamp, int matchesPerPage = 10)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(timestamp);

        var endpoint = new Endpoint<MatchesModel>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("matches.json")
                   .SetQueryParam("timestamp", timestamp)
                   .SetQueryParam("matches_per_page", $"{matchesPerPage}")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<MatchesModel> GetMatches(string cursor, int matchesPerPage = 10)
    {
        if (string.IsNullOrWhiteSpace(cursor))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(cursor));

        var endpoint = new Endpoint<MatchesModel>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("matches.json")
                   .SetQueryParam("cursor", cursor)
                   .SetQueryParam("matches_per_page", $"{matchesPerPage}")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<Match> GetMatchById(string matchId)
    {
        if (string.IsNullOrWhiteSpace(matchId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(matchId));

        var endpoint = new Endpoint<Match>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("matches")
                   .AppendPathSegment($"{matchId}.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<List<Player>> GetPlayers(int page = 1)
    {
        var endpoint = new Endpoint<List<Player>>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players.json")
                   .SetQueryParam("page", page)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<List<Player>> GetPlayers(string name, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

        var endpoint = new Endpoint<List<Player>>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players.json")
                   .SetQueryParam("filter[name]", name)
                   .SetQueryParam("page", page)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<Player> GetPlayerById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        var endpoint = new Endpoint<Player>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{id}.json")
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerMatches> GetPlayerMatches(string playerId, string? timeFrame = null,
        int? page = null, int? matchesPerPage = null, int? heroId = null, string? role = null,
        int? occurringHeroId = null, string? playerName = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var endpoint = new Endpoint<PlayerMatches>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{playerId}/matches.json")
                   .SetQueryParam("page", page)
                   .SetQueryParam("per_page", matchesPerPage)
                   .SetQueryParam("time_frame", timeFrame)
                   .SetQueryParam("filter[hero_id]", heroId)
                   .SetQueryParam("filter[role]", role)
                   .SetQueryParam("filter[player_name]", playerName)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerMatches> GetPlayerMatches(string playerId, TimeFrame? timeFrame = null,
        int? page = null, int? matchesPerPage = null, int? heroId = null, Role? role = null, string? playerName = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var endpoint = new Endpoint<PlayerMatches>(BaseUrl);


        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{playerId}/matches.json")
                   .SetQueryParam("page", page)
                   .SetQueryParam("per_page", matchesPerPage)
                   .SetQueryParam("time_frame", timeFrame?.ToStringValue())
                   .SetQueryParam("filter[hero_id]", heroId)
                   .SetQueryParam("filter[role]", role?.ToStringValue(), false)
                   .SetQueryParam("filter[player_name]", playerName)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerStatistics> GetPlayerStatistics(string playerId, TimeFrame? timeFrame = null)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var endpoint = new Endpoint<PlayerStatistics>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{playerId}")
                   .AppendPathSegment("statistics.json")
                   .SetQueryParam("time_frame", timeFrame?.ToStringValue())
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<PlayerHeroStatistics> GetPlayerHeroStatistics(string playerId, int[] heroIds)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        if (heroIds.Length < 1) throw new ArgumentOutOfRangeException(nameof(heroIds));

        var idsString = "[" + string.Join(", ", heroIds) + "]";

        var endpoint = new Endpoint<PlayerHeroStatistics>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{playerId}")
                   .AppendPathSegment("hero_statistics.json")
                   .SetQueryParam("hero_ids", idsString)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }

    public static async Task<TeammatesModel> GetPlayerTeammates(string playerId, TimeFrame timeFrame = TimeFrame.All,
        int count = 10)
    {
        if (string.IsNullOrWhiteSpace(playerId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerId));

        var endpoint = new Endpoint<TeammatesModel>(BaseUrl);

        return await endpoint
                   .AppendPathSegment("players")
                   .AppendPathSegment($"{playerId}")
                   .AppendPathSegment("common_teammates.json")
                   .SetQueryParam("time_frame", timeFrame.ToStringValue())
                   .SetQueryParam("count", count)
                   .GetAsync()
               ?? throw new InvalidOperationException();
    }
}