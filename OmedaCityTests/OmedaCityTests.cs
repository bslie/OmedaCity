using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using OmedaCity;
using OmedaCity.Enums;
using OmedaCity.Models;

namespace OmedaCityTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class OmedaCityTests
{
    private static void NotNull<T>([NotNull] T t)
    {
        _ = t ?? throw new ArgumentNullException();
    }

    [Test]
    public async Task TestGetBuilds()
    {
        var builds = await OmedaCityClientApi.GetBuilds();
        NotNull(builds);
        if (builds.Count < 1) Assert.Fail();
    }


    [Test]
    public async Task TestGetBuildById()
    {
        var build = await OmedaCityClientApi.GetBuildById(1);
        NotNull(build);
    }

    [Test]
    public void TestGetBuildByIdWithInvalidId()
    {
        var ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => OmedaCityClientApi.GetBuildById(0));
        if (ex != null) Assert.That(ex.ParamName, Is.EqualTo("id"));
    }

    [Test]
    public async Task TestGetHeroStatistics()
    {
        var stats = await OmedaCityClientApi.GetHeroStatistics();
        NotNull(stats);
        if (stats.HeroStatistics is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public async Task TestGetHeroStatisticsWithIdsAndTimeFrame()
    {
        var stats = await OmedaCityClientApi.GetHeroStatistics(new[] { 1, 2, 3 }, TimeFrame.All);
        NotNull(stats);
        if (stats.HeroStatistics is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public async Task TestGetHeroStatisticsWithIds()
    {
        var stats = await OmedaCityClientApi.GetHeroStatistics(new[] { 1, 2, 3 });
        NotNull(stats);
        if (stats.HeroStatistics is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public async Task TestGetHeroStatisticsWithTimeFrame()
    {
        var stats = await OmedaCityClientApi.GetHeroStatistics(new[] { 1, 2, 4 });
        NotNull(stats);
        if (stats.HeroStatistics is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public void TestEnumTimeFrameToStringValue()
    {
        var timeFrame = TimeFrame.W3;
        Assert.That(timeFrame.ToStringValue(), Is.EqualTo("3W"));
    }

    [Test]
    public async Task TestGetHeroes()
    {
        var heroes = await OmedaCityClientApi.GetHeroes();
        NotNull(heroes);
        if (heroes.Count < 1) Assert.Fail();
    }

    [Test]
    public async Task TestGetHeroByName()
    {
        var hero = await OmedaCityClientApi.GetHeroByName("Morigesh");
        NotNull(hero);
    }

    [Test]
    public async Task TestGetItems()
    {
        var items = await OmedaCityClientApi.GetItems();
        NotNull(items);
        if (items.Count < 1) Assert.Fail();
    }

    [Test]
    public async Task TestGetItemByName()
    {
        var item = await OmedaCityClientApi.GetItemByName("Wraith_SonarDrone");
        NotNull(item);
    }

    [Test]
    public void TestGetItemByInvalidSpaceName()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            OmedaCityClientApi.GetItemByName(" "));
        if (ex != null) Assert.That(ex?.Message, Is.EqualTo("Value cannot be null or whitespace. (Parameter 'name')"));
    }

    [Test]
    public void TestGetHeroByInvalidSpaceName()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            OmedaCityClientApi.GetHeroByName(" "));
        if (ex != null) Assert.That(ex?.Message, Is.EqualTo("Value cannot be null or whitespace. (Parameter 'name')"));
    }

    [Test]
    public async Task TestGetMatchesWithUnix()
    {
        var matches = await OmedaCityClientApi.GetMatches(1703254925);
        NotNull(matches);
        if (matches.Matches is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public async Task TestGetMatchesWithCursor()
    {
        var matches =
            await OmedaCityClientApi.GetMatches(
                "MjAyMy0xMi0yMiAxNDoyMDozMCBVVEMjM2UxYzhmMzYtNTY2Ni00NTVjLTgwZjMtNGQyMzA3YTNiNGJh");
        NotNull(matches);
        if (matches.Matches is { Count: < 1 }) Assert.Fail();
    }

    [Test]
    public async Task TestGetMatchById()
    {
        var match = await OmedaCityClientApi.GetMatchById("20d89b05-9a8d-4aea-b7ed-027979d5c145");
        NotNull(match);
    }

    [Test]
    public async Task TestGetPlayers()
    {
        var players = await OmedaCityClientApi.GetPlayers();
        NotNull(players);
        if (players.Count < 1) Assert.Fail();
    }

    [Test]
    public async Task TestGetPlayersByName()
    {
        var players = await OmedaCityClientApi.GetPlayers("C0re");
        NotNull(players);
        if (players.Count < 1) Assert.Fail();
    }

    [Test]
    public void TestGetPlayersByInvalidName()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            OmedaCityClientApi.GetPlayers(" "));
        if (ex != null) Assert.That(ex?.Message, Is.EqualTo("Value cannot be null or whitespace. (Parameter 'name')"));
    }

    [Test]
    public async Task TestGetPlayerById()
    {
        var player = await OmedaCityClientApi.GetPlayerById("f54aa025-afa4-43bb-b75c-b225d1bd7a56");
        NotNull(player);
    }


    [Test]
    public void TestGetPlayerByWhiteSpaceId()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(() =>
            OmedaCityClientApi.GetPlayerById(" "));
        if (ex != null) Assert.That(ex?.Message, Is.EqualTo("Value cannot be null or whitespace. (Parameter 'id')"));
    }

    [Test]
    public async Task TestGetPlayerMatches()
    {
        var playerMatches = await OmedaCityClientApi.GetPlayerMatches("f54aa025-afa4-43bb-b75c-b225d1bd7a56",
            TimeFrame.W1, role: Role.Carry);
        NotNull(playerMatches);
        if (playerMatches.Matches is { Count: < 1 }) Assert.Fail("The result is less then 1");
    }

    [Test]
    public async Task TestGetPlayerStatistics()
    {
        var statistics =
            await OmedaCityClientApi.GetPlayerStatistics("f54aa025-afa4-43bb-b75c-b225d1bd7a56", TimeFrame.D1);
        NotNull(statistics);
    }

    [Test]
    public async Task TestGetPlayerHeroStatistics()
    {
        var statistics =
            await OmedaCityClientApi.GetPlayerHeroStatistics("f54aa025-afa4-43bb-b75c-b225d1bd7a56", new[] { 1, 4, 8 });
        NotNull(statistics);
        if (statistics.HeroStatistics is { Count: < 1 }) Assert.Fail("The result is less then 1");
    }

    [Test]
    public async Task TestGetPlayerHeroStatisticsWithInvalidIds()
    {
        var statistics =
            await OmedaCityClientApi.GetPlayerHeroStatistics("f54aa025-afa4-43bb-b75c-b225d1bd7a56", new[] { 0, 0 });
        if (statistics.HeroStatistics is { Count: < 1 }) Assert.Pass("The result is less then 1");
    }

    [Test]
    public async Task TestGetPlayerTeammates()
    {
        var teammates = await OmedaCityClientApi.GetPlayerTeammates("f54aa025-afa4-43bb-b75c-b225d1bd7a56", count: 30);
        NotNull(teammates);
        if (teammates.Teammates is { Count: < 1 }) Assert.Fail("The result is less then 1");
    }
}