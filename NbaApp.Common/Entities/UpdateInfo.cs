using System;

namespace NbaApp.Common.Entities
{
    public class UpdateInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public UpdateInfo()
        {

        }
    }
}
