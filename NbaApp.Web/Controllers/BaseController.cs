using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class BaseController
    {
        private readonly ApiService _apiService;
        private readonly Context _context;

        public BaseController(ApiService apiService, Context context)
        {
            _apiService = apiService;
            _context = context;
        }
    }
}
