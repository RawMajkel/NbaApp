using System;

namespace NbaApp.Web.Responses
{
    public class InfoResponse
    {
        public string UpdateDate { get; set; }

        public InfoResponse(string updateDate)
        {
            UpdateDate = updateDate;
        }
    }
}
