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
 - https://localhost:5001/api/info -> Get informations about the App

### Examples
 - Get LeBron James data by ID -> https://localhost:5001/api/player/b5afd3b6-337a-44a0-9057-a4c63652b05d
 - Get LeBron James data by name -> https://localhost:5001/api/player/LeBron/James
 - Get LeBron James current statistics -> https://localhost:5001/api/player-stats/b5afd3b6-337a-44a0-9057-a4c63652b05d
 - Get Boston Celtics data by nickname -> https://localhost:5001/api/team/Celtics
 - Get Boston Celtics players -> https://localhost:5001/api/players/9e841b57-3b01-4ae8-9e5b-bf08d87e613c
