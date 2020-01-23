using Microsoft.AspNetCore.Mvc;
using NbaApp.Common.Entities;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class AppController : BaseController
    {
        public AppController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("info")]
        public async Task<ActionResult<AppResponse>> GetAppInfo()
        {
            var info = await _apiService.Get<AppInfo>();

            return new AppResponse(string.Format("{0:dd-MM-yyyy}", info.FirstOrDefault().UpdateDate));
        }
    }
}
