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

    /// <summary>
    ///     Asynchronously retrieves a list of Build objects from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "builds.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a list of Build objects. This JSON string is then deserialized into a List of Build objects.
    /// </remarks>
    /// <returns>
    ///     A Task resulting in a List of Build objects retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<List<Build>> GetBuilds()
    {
        var buildsJson = await BaseUrl
            .AppendPathSegment("builds.json")
            .GetAsync()
            .ReceiveString();

        return JsonConvert.DeserializeObject<List<Build>>(buildsJson) ?? throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves a specific Build object from a remote source by its ID.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "builds" and "{id}.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a Build object. This JSON string is then deserialized into a Build object.
    /// </remarks>
    /// <param name="id">
    ///     The ID of the Build object to be retrieved. Must be greater than 0.
    /// </param>
    /// <returns>
    ///     A Task resulting in a Build object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided ID is less than or equal to 0.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a HeroStatisticsModel object from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "dashboard" and "hero_statistics.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a HeroStatisticsModel object. This JSON string is then deserialized into a HeroStatisticsModel object.
    /// </remarks>
    /// <returns>
    ///     A Task resulting in a HeroStatisticsModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<HeroStatisticsModel> GetHeroStatistics()
    {
        var buildJson = await BaseUrl
            .AppendPathSegments("dashboard", "hero_statistics.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<HeroStatisticsModel>(buildJson) ?? throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves a HeroStatisticsModel object for specific heroes and a specified time frame from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "dashboard" and "hero_statistics.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a HeroStatisticsModel object. This JSON string is then deserialized into a HeroStatisticsModel object.
    /// </remarks>
    /// <param name="heroIds">
    ///     An array of hero IDs for which statistics are to be retrieved. The array must contain at least one ID.
    /// </param>
    /// <param name="timeFrame">
    ///     A TimeFrame enum value specifying the time frame for which statistics are to be retrieved. Must be a valid
    ///     TimeFrame enum value.
    /// </param>
    /// <returns>
    ///     A Task resulting in a HeroStatisticsModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided heroIds array is empty.
    /// </exception>
    /// <exception cref="InvalidEnumArgumentException">
    ///     Thrown when the provided timeFrame is not a valid TimeFrame enum value.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a HeroStatisticsModel object for specific heroes from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "dashboard" and "hero_statistics.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a HeroStatisticsModel object. This JSON string is then deserialized into a HeroStatisticsModel object.
    /// </remarks>
    /// <param name="heroIds">
    ///     An array of hero IDs for which statistics are to be retrieved. The array must contain at least one ID.
    /// </param>
    /// <returns>
    ///     A Task resulting in a HeroStatisticsModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided heroIds array is empty.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a HeroStatisticsModel object for a specified time frame from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "dashboard" and "hero_statistics.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a HeroStatisticsModel object. This JSON string is then deserialized into a HeroStatisticsModel object.
    /// </remarks>
    /// <param name="timeFrame">
    ///     A TimeFrame enum value specifying the time frame for which statistics are to be retrieved. Must be a valid
    ///     TimeFrame enum value.
    /// </param>
    /// <returns>
    ///     A Task resulting in a HeroStatisticsModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">
    ///     Thrown when the provided timeFrame is not a valid TimeFrame enum value.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a list of Hero objects from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "heroes.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a list of Hero objects. This JSON string is then deserialized into a List of Hero objects.
    /// </remarks>
    /// <returns>
    ///     A Task resulting in a List of Hero objects retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<List<Hero>> GetHeroes()
    {
        var heroesJson = await BaseUrl
            .AppendPathSegment("heroes.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Hero>>(heroesJson) ?? throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves a Hero object with a specified name from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "heroes" and "{name}.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a Hero object. This JSON string is then deserialized into a Hero object.
    /// </remarks>
    /// <param name="name">
    ///     The name of the hero to be retrieved. The name cannot be null, empty, or consist only of white-space characters.
    /// </param>
    /// <returns>
    ///     A Task resulting in a Hero object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided name is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a list of Item objects from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "items.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a list of Item objects. This JSON string is then deserialized into a List of Item objects.
    /// </remarks>
    /// <returns>
    ///     A Task resulting in a List of Item objects retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<List<Item>> GetItems()
    {
        var itemsJson = await BaseUrl
            .AppendPathSegment("items.json")
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Item>>(itemsJson) ?? throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves an Item object with a specified name from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "items" and "{name}.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     an Item object. This JSON string is then deserialized into an Item object.
    /// </remarks>
    /// <param name="name">
    ///     The name of the item to be retrieved. The name cannot be null, empty, or consist only of white-space characters.
    /// </param>
    /// <returns>
    ///     A Task resulting in an Item object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided name is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a MatchesModel object for a specified timestamp and number of matches per page from a
    ///     remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "matches.json" to the path,
    ///     sets the query parameters for "timestamp" and "matches_per_page", and then awaits the response.
    ///     The response is expected to be a JSON string representing a MatchesModel object.
    ///     This JSON string is then deserialized into a MatchesModel object.
    /// </remarks>
    /// <param name="timestamp">
    ///     A long value specifying the UNIX timestamp for which matches are to be retrieved. Must be greater than 0.
    /// </param>
    /// <param name="matchesPerPage">
    ///     An integer value specifying the number of matches per page. Default value is 10.
    /// </param>
    /// <returns>
    ///     A Task resulting in a MatchesModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided timestamp is less than or equal to 0.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a MatchesModel object for a specified date and time and number of matches per page from a
    ///     remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "matches.json" to the path,
    ///     sets the query parameters for "timestamp" and "matches_per_page", and then awaits the response.
    ///     The timestamp is calculated as the number of seconds since the Unix epoch (1970-01-01T00:00:00Z) from the provided
    ///     DateTime object.
    ///     The response is expected to be a JSON string representing a MatchesModel object.
    ///     This JSON string is then deserialized into a MatchesModel object.
    /// </remarks>
    /// <param name="dateTime">
    ///     A DateTime object specifying the date and time for which matches are to be retrieved.
    /// </param>
    /// <param name="matchesPerPage">
    ///     An integer value specifying the number of matches per page. Default value is 10.
    /// </param>
    /// <returns>
    ///     A Task resulting in a MatchesModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a MatchesModel object for a specified cursor and number of matches per page from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "matches.json" to the path,
    ///     sets the query parameters for "cursor" and "matches_per_page", and then awaits the response.
    ///     The response is expected to be a JSON string representing a MatchesModel object.
    ///     This JSON string is then deserialized into a MatchesModel object.
    /// </remarks>
    /// <param name="cursor">
    ///     A string value specifying the cursor for which matches are to be retrieved. The cursor cannot be null, empty, or
    ///     consist only of white-space characters.
    /// </param>
    /// <param name="matchesPerPage">
    ///     An integer value specifying the number of matches per page. Default value is 10.
    /// </param>
    /// <returns>
    ///     A Task resulting in a MatchesModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided cursor is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a Match object with a specified match ID from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "matches" and "{matchId}.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a Match object. This JSON string is then deserialized into a Match object.
    /// </remarks>
    /// <param name="matchId">
    ///     The ID of the match to be retrieved. The match ID cannot be null, empty, or consist only of white-space characters.
    /// </param>
    /// <returns>
    ///     A Task resulting in a Match object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided match ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a list of Player objects from a remote source, with pagination.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players.json" to the path,
    ///     sets the query parameter for "page", and then awaits the response.
    ///     The response is expected to be a JSON string representing a list of Player objects.
    ///     This JSON string is then deserialized into a List of Player objects.
    /// </remarks>
    /// <param name="page">
    ///     An integer value specifying the page number for the players list to be retrieved. Default value is 1.
    /// </param>
    /// <returns>
    ///     A Task resulting in a List of Player objects retrieved from the remote source.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<List<Player>> GetPlayers(int page = 1)
    {
        var playersJson = await BaseUrl
            .AppendPathSegment("players.json")
            .SetQueryParam("page", page)
            .GetAsync()
            .ReceiveString();
        return JsonConvert.DeserializeObject<List<Player>>(playersJson) ?? throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves a list of Player objects with a specified name from a remote source, with pagination.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players.json" to the path,
    ///     sets the query parameters for "q[name]" and "page", and then awaits the response.
    ///     The response is expected to be a JSON string representing a list of Player objects.
    ///     This JSON string is then deserialized into a List of Player objects.
    /// </remarks>
    /// <param name="name">
    ///     A string value specifying the name of the players to be retrieved. The name cannot be null, empty, or consist only
    ///     of white-space characters.
    /// </param>
    /// <param name="page">
    ///     An integer value specifying the page number for the players list to be retrieved. Default value is 1.
    /// </param>
    /// <returns>
    ///     A Task resulting in a List of Player objects retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided name is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a Player object with a specified ID from a remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players" and "{id}.json" to the path,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a Player object. This JSON string is then deserialized into a Player object.
    /// </remarks>
    /// <param name="id">
    ///     The ID of the player to be retrieved. The ID cannot be null, empty, or consist only of white-space characters.
    /// </param>
    /// <returns>
    ///     A Task resulting in a Player object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a PlayerMatches object with a specified player ID and optional filters from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players", "{playerId}/matches.json" to the path,
    ///     sets the query parameters for page, matches per page, time frame, hero ID, role, occurring hero ID, and player
    ///     name,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a PlayerMatches object. This JSON string is then deserialized into a PlayerMatches object.
    /// </remarks>
    /// <param name="playerId">
    ///     The ID of the player for which matches are to be retrieved. The player ID cannot be null, empty, or consist only of
    ///     white-space characters.
    /// </param>
    /// <param name="timeFrame">
    ///     An optional string value specifying the time frame for the matches to be retrieved.
    /// </param>
    /// <param name="page">
    ///     An optional integer value specifying the page number for the matches list to be retrieved.
    /// </param>
    /// <param name="matchesPerPage">
    ///     An optional integer value specifying the number of matches per page.
    /// </param>
    /// <param name="heroId">
    ///     An optional integer value specifying the ID of the hero for the matches to be retrieved.
    /// </param>
    /// <param name="role">
    ///     An optional string value specifying the role for the matches to be retrieved.
    /// </param>
    /// <param name="occurringHeroId">
    ///     An optional integer value specifying the ID of the occurring hero for the matches to be retrieved.
    /// </param>
    /// <param name="playerName">
    ///     An optional string value specifying the name of the player for the matches to be retrieved.
    /// </param>
    /// <returns>
    ///     A Task resulting in a PlayerMatches object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided player ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a PlayerMatches object with a specified player ID and optional filters from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players", "{playerId}/matches.json" to the path,
    ///     sets the query parameters for page, matches per page, time frame, hero ID, role, occurring hero ID, and player
    ///     name,
    ///     and then awaits the response. The response is expected to be a JSON string representing
    ///     a PlayerMatches object. This JSON string is then deserialized into a PlayerMatches object.
    /// </remarks>
    /// <param name="playerId">
    ///     The ID of the player for which matches are to be retrieved. The player ID cannot be null, empty, or consist only of
    ///     white-space characters.
    /// </param>
    /// <param name="timeFrame">
    ///     An optional TimeFrame enum value specifying the time frame for the matches to be retrieved.
    /// </param>
    /// <param name="page">
    ///     An optional integer value specifying the page number for the matches list to be retrieved.
    /// </param>
    /// <param name="matchesPerPage">
    ///     An optional integer value specifying the number of matches per page.
    /// </param>
    /// <param name="heroId">
    ///     An optional integer value specifying the ID of the hero for the matches to be retrieved.
    /// </param>
    /// <param name="role">
    ///     An optional Role enum value specifying the role for the matches to be retrieved.
    /// </param>
    /// <param name="occurringHeroId">
    ///     An optional integer value specifying the ID of the occurring hero for the matches to be retrieved.
    /// </param>
    /// <param name="playerName">
    ///     An optional string value specifying the name of the player for the matches to be retrieved.
    /// </param>
    /// <returns>
    ///     A Task resulting in a PlayerMatches object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided player ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a PlayerStatistics object with a specified player ID and optional time frame from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players", "{playerId}", and "statistics.json" to the
    ///     path,
    ///     sets the query parameter for time frame, and then awaits the response. The response is expected to be a JSON string
    ///     representing
    ///     a PlayerStatistics object. This JSON string is then deserialized into a PlayerStatistics object.
    /// </remarks>
    /// <param name="playerId">
    ///     The ID of the player for which statistics are to be retrieved. The player ID cannot be null, empty, or consist only
    ///     of white-space characters.
    /// </param>
    /// <param name="timeFrame">
    ///     An optional TimeFrame enum value specifying the time frame for the statistics to be retrieved.
    /// </param>
    /// <returns>
    ///     A Task resulting in a PlayerStatistics object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided player ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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

    /// <summary>
    ///     Asynchronously retrieves a PlayerHeroStatistics object with a specified player ID and array of hero IDs from a
    ///     remote source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players", "{playerId}", and "hero_statistics.json" to
    ///     the path,
    ///     sets the query parameter for hero IDs, and then awaits the response. The response is expected to be a JSON string
    ///     representing
    ///     a PlayerHeroStatistics object. This JSON string is then deserialized into a PlayerHeroStatistics object.
    /// </remarks>
    /// <param name="playerId">
    ///     The ID of the player for which hero statistics are to be retrieved. The player ID cannot be null, empty, or consist
    ///     only of white-space characters.
    /// </param>
    /// <param name="heroIds">
    ///     An array of integer values specifying the IDs of the heroes for which statistics are to be retrieved. The array
    ///     cannot be empty.
    /// </param>
    /// <returns>
    ///     A Task resulting in a PlayerHeroStatistics object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided player ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when the provided hero IDs array is empty.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
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
        return JsonConvert.DeserializeObject<PlayerHeroStatistics>(statisticsJson) ??
               throw new InvalidOperationException();
    }

    /// <summary>
    ///     Asynchronously retrieves a TeammatesModel object with a specified player ID, time frame, and count from a remote
    ///     source.
    /// </summary>
    /// <remarks>
    ///     This method sends a GET request to a specified URL, appends "players", "{playerId}", and "common_teammates.json" to
    ///     the path,
    ///     sets the query parameters for time frame and count, and then awaits the response. The response is expected to be a
    ///     JSON string representing
    ///     a TeammatesModel object. This JSON string is then deserialized into a TeammatesModel object.
    /// </remarks>
    /// <param name="playerId">
    ///     The ID of the player for which common teammates are to be retrieved. The player ID cannot be null, empty, or
    ///     consist only of white-space characters.
    /// </param>
    /// <param name="timeFrame">
    ///     A TimeFrame enum value specifying the time frame for the teammates to be retrieved. The default value is
    ///     TimeFrame.All.
    /// </param>
    /// <param name="count">
    ///     An integer value specifying the number of teammates to be retrieved. The default value is 10.
    /// </param>
    /// <returns>
    ///     A Task resulting in a TeammatesModel object retrieved from the remote source.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the provided player ID is null, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the deserialization of the JSON string fails, resulting in a null value.
    /// </exception>
    public static async Task<TeammatesModel> GetPlayerTeammates(string playerId, TimeFrame timeFrame = TimeFrame.All,
        int count = 10)
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