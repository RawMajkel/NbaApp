using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class StandingsController : BaseController
    {
        public StandingsController(ApiService apiService, Context context) : base(apiService, context)
        {

        }
    }
}
