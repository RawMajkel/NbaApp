namespace NbaApp.Web.Responses
{
    public class AppResponse
    {
        public string UpdateDate { get; set; }

        public AppResponse(string updateDate)
        {
            UpdateDate = updateDate;
        }
    }
}
