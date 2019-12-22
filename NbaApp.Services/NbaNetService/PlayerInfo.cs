using NbaApp.Common.Entities;

namespace NbaApp.Services.NbaNetClasses
{
    public class PlayerInfo
    {
        public Player Player { get; set; }
        public PlayerCareerInfo PlayerCareerInfo { get; set; }

        public PlayerInfo(Player player, PlayerCareerInfo playerCareerInfo)
        {
            Player = player;
            PlayerCareerInfo = playerCareerInfo;
        }
    }
}
