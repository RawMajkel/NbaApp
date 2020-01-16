using System;

namespace NbaApp.Common.Entities
{
    public class AppInfo : BaseEntity
    {
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public AppInfo()
        {

        }
    }
}
