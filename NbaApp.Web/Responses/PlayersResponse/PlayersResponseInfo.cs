namespace NbaApp.Web.Responses
{
    public class PlayersResponseInfo
    {
        public int Total { get; set; }
        public int LastPage { get; set; }

        public PlayersResponseInfo(int total, int lastPage)
        {
            Total = total;
            LastPage = lastPage;
        }
    }
}
