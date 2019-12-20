using NbaApp.Persistance;
using NbaApp.Services;
namespace NbaApp.Web.Controllers
{
    public class TeamController : BaseController
    {
        public TeamController(ApiService apiService, Context context) : base(apiService, context)
        {

        }
    }
}
