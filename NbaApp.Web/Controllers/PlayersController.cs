using Microsoft.AspNetCore.Mvc;
using NbaApp.Persistance;
using NbaApp.Services;
using NbaApp.Web.Messages.Responses;
using System;
using System.Threading.Tasks;

namespace NbaApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : BaseController
    {
        public PlayersController(ApiService apiService, Context context) : base(apiService, context)
        {

        }

        [HttpGet("details/{id:guid}")]
        public async Task<ActionResult<PlayerResponse>> Get(Guid id)
        {
            // var post = await Task.FromResult(_repository.GetBlogData()
            //     .SelectMany(x => x.Posts)
            //     .FirstOrDefault(x => x.Id == id));

            // if (post == null)
            // {
            //     return NotFound();
            // }

            // return new PostDetailsResponse
            // (
            //     post.Id,
            //     post.Title,
            //     post.Content,
            //     post.CreatedOn
            // );
            return new PlayerResponse();
        }
    }
}
