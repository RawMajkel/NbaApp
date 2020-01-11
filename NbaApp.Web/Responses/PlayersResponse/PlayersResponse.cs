using System.Collections.Generic;

namespace NbaApp.Web.Responses
{
    public class PlayersResponse
    {
        public List<PlayerResponse> Players { get; set; }
        public PlayersResponseInfo Meta { get; set; }

        public PlayersResponse()
        {

        }
    }
}
