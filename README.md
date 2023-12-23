<h1 align="center" id="title">Omeda City Client API</h1>

<p align="center"><img src="https://omeda.city/assets/content/banner-24f4789cebe99d4408f94ed46ab0f2c008f659410128a05a3f8a2c1881a951fe.jpg" alt="project-image"></p>

<p id="description">A lightweight API client written in C# to optimize your time when developing projects for the Predecessor game.</p>

  
  
<h2>🧐 Features</h2>

Here're some of the project's best features:

*   Easy to maintain
*   Highly documented
*   Minimal conditions
*   Wrapped in NUnit tests

<h2>🛠️ Installation Steps:</h2>

<p>1. Installation via command line using dotnet CLI.</p>

```ruby
dotnet package OmedaCity
```

<h2>Example</h2>

```C#
using OmedaCity;
using OmedaCity.Enums;

public async Task GetPlayerById()
{
    var player = await OmedaCityClientApi.GetPlayerById("<PLAYER ID FROM OMEDA CITY>");
    Console.WriteLine($"Name: {player.DisplayName}");
    Console.WriteLine($"MMR: {player.Mmr}");
    Console.WriteLine($"Rank: {player.RankTitle}");
}

```
  
<h2>💻 Built with</h2>

Technologies used in the project:

*   C# 6.0
*   Flurl 4.0
*   Newtonsoft.Json 13.0.3
