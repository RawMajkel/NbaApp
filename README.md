# NbaApp

NbaApp is an ASP.NET Core Web API application.
It requires .NET Core 3.1.0 (https://dotnet.microsoft.com/download/dotnet-core/3.1) and Visual Studio 2019 16.4 or later (https://docs.microsoft.com/pl-pl/visualstudio/releases/2019/release-notes)

## Web API
 - https://localhost:5001/api/players/ -> Get all active NBA players
 - https://localhost:5001/api/players/{guid:id} -> Get players from specific team by team ID
 - https://localhost:5001/api/player/{guid:id} -> Get specific player by player's ID
 - https://localhost:5001/api/player/{firstName}/{lastName} -> Get specific player by name
 - https://localhost:5001/api/player-stats/{guid:id} -> Get player stats by player's ID
 - https://localhost:5001/api/teams/ -> Get all teams
 - https://localhost:5001/api/team/{guid:id} -> Get specific team by team ID
 - https://localhost:5001/api/team/{nickName} -> Get specific team by nickname

### Examples
 - Get LeBron James data by ID -> https://localhost:5001/api/player/7b2ef5af-c1ca-4c95-af22-b79d5a4ccfe4
 - Get LeBron James data by name -> https://localhost:5001/api/player/LeBron/James
 - Get LeBron James current statistics -> https://localhost:5001/api/player-stats/7b2ef5af-c1ca-4c95-af22-b79d5a4ccfe4
 - Get Boston Celtics data by nickname -> https://localhost:5001/api/team/Celtics
 - Get Boston Celtics players -> https://localhost:5001/api/players/24544c21-df08-4839-8631-99f4f5911f21
