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
 - LeBron James data -> https://localhost:5001/api/player/f21d7c4b-f4c0-432c-9ae2-5d7b5495b20f
 - LeBron James current statistics -> https://localhost:5001/api/player-stats/f21d7c4b-f4c0-432c-9ae2-5d7b5495b20f
 - Boston Celtics players -> https://localhost:5001/api/players/ff948c74-60e7-454b-8ad9-b92cd327001b
 - Boston Celtics statistics -> https://localhost:5001/api/team-stats/ff948c74-60e7-454b-8ad9-b92cd327001b
