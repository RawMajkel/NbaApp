using Microsoft.AspNetCore.Mvc;
using NbaApp.Services;
using NbaApp.Web.Responses;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VersionController : BaseController
    {
        public VersionController(ApiService apiService) : base(apiService)
        {

        }

        [HttpGet("info")]
        public async Task<ActionResult<InfoResponse>> GetAppInfo()
        {
            var info = await _apiService.GetInfo();

            return new InfoResponse(string.Format("{0:dd-MM-yyyy}", info.UpdateDate));
        }
    }
}
