using NbaApp.Common.Entities;

namespace NbaApp.Services.NbaNetClasses
{
    public class PlayerInfo
    {
        /* Properties */
        public Player Player { get; set; }
        public PlayerCareerInfo PlayerCareerInfo { get; set; }

        /* Constructors */
        public PlayerInfo(Player player, PlayerCareerInfo playerCareerInfo)
        {
            Player = player;
            PlayerCareerInfo = playerCareerInfo;
        }
    }
}
