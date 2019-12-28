# NbaApp

NbaApp is an ASP.NET Core Web API application.
It requires .NET Core 3.1.0 (https://dotnet.microsoft.com/download/dotnet-core/3.1) and Visual Studio 2019 16.4 or later (https://docs.microsoft.com/pl-pl/visualstudio/releases/2019/release-notes)

## Web API
 - https://localhost:5001/api/player/{guid} -> Get specific player by ID
 - https://localhost:5001/api/player-stats/{guid} -> Get player stats by ID
 - https://localhost:5001/api/players/{guid} -> Get players from specific team by ID
 - https://localhost:5001/api/team/{guid} -> Get specific team by ID
 - https://localhost:5001/api/teams/ -> Get all teams
 - https://localhost:5001/api/team-stats/{guid} -> Get team stats by ID

### Examples
 - LeBron James data -> https://localhost:5001/api/player/BBFE2A4F-57B3-4FBE-917D-D123A835179D
 - LeBron James current statistics -> https://localhost:5001/api/player-stats/BBFE2A4F-57B3-4FBE-917D-D123A835179D
 - Boston Celtics players -> https://localhost:5001/api/players/31CFED00-2BD1-4D07-83E1-7AF36302FD9B
 - Boston Celtics statistics -> https://localhost:5001/api/team-stats/31CFED00-2BD1-4D07-83E1-7AF36302FD9B
