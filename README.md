# NbaApp

NbaApp is an ASP.NET Core Web API application.
It requires .NET Core 3.1.0 (https://dotnet.microsoft.com/download/dotnet-core/3.1) and Visual Studio 2019 16.4 or later (https://docs.microsoft.com/pl-pl/visualstudio/releases/2019/release-notes)

## Web API
 - https://localhost:5001/api/players/ -> Get all active NBA players
 - https://localhost:5001/api/player/{guid} -> Get specific player by ID
 - https://localhost:5001/api/player-stats/{guid} -> Get player stats by ID
 - https://localhost:5001/api/players/{guid} -> Get players from specific team by ID
 - https://localhost:5001/api/team/{guid} -> Get specific team by ID
 - https://localhost:5001/api/teams/ -> Get all teams
 - https://localhost:5001/api/team-stats/{guid} -> Get team stats by ID

### Examples
 - LeBron James data -> https://localhost:5001/api/player/58F8900C-990B-490D-B92B-7A527422913A
 - LeBron James current statistics -> https://localhost:5001/api/player-stats/58F8900C-990B-490D-B92B-7A527422913A
 - Boston Celtics players -> https://localhost:5001/api/players/69AF6E92-E556-43F4-8ACC-E476C139C92E
 - Boston Celtics statistics -> https://localhost:5001/api/team-stats/69AF6E92-E556-43F4-8ACC-E476C139C92E
