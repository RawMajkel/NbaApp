using System.Collections.Generic;

namespace NbaApp.Web.Responses
{
    public class PlayersResponse
    {
        public IEnumerable<PlayerResponse> Players { get; set; }
        public EntityInfo Meta { get; set; }

        public PlayersResponse()
        {

        }
    }
}
