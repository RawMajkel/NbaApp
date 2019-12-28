using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class TeamsController : BaseController
    {
        public TeamsController(ApiService apiService, Context context) : base(apiService, context)
        {

        }
    }
}
