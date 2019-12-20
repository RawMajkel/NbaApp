using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class PlayerController : BaseController
    {
        public PlayerController(ApiService apiService, Context context) : base(apiService, context)
        {

        }
    }
}
