using Microsoft.AspNetCore.Mvc;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ApiService _apiService;

        public BaseController(ApiService apiService)
        {
            _apiService = apiService;
        }
    }
}
