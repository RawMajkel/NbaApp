using Microsoft.AspNetCore.Mvc;
using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class BaseController : ControllerBase
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
