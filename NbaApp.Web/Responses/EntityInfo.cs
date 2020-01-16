namespace NbaApp.Web.Responses
{
    public class EntityInfo
    {
        public int Total { get; set; }
        public int LastPage { get; set; }

        public EntityInfo(int total, int lastPage)
        {
            Total = total;
            LastPage = lastPage;
        }
    }
}
