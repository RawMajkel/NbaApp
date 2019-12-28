using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NbaApp.Persistance;
using NbaApp.Services;
using NbaApp.Web.Messages.Responses;
using System;
using System.Linq;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PlayerResponse>> Get(Guid id)
        {           
            var player = await Task.FromResult(_context.Players
                .Include(x => x.CareerInfo)
                .FirstOrDefault(x => x.ID == id));

            if (player is null)
            {
                return NotFound();
            }

            return new PlayerResponse(
                player.FirstName,
                player.LastName,
                player.DateOfBirth,
                player.NbaNetID,
                player.Age,
                player.HeightMetric,
                player.HeightFeet,
                player.HeightInches,
                player.WeightPounds,
                player.WeightKilograms,
                player.CurrentTeam,
                player.CareerInfo.College,
                player.CareerInfo.Country,
                player.CareerInfo.JerseyNumber,
                player.CareerInfo.YearsPro,
                player.CareerInfo.Position,
                player.CareerInfo.DraftYear,
                player.CareerInfo.DraftRound,
                player.CareerInfo.DraftPick,
                player.CareerInfo.DraftTeam.GetValueOrDefault()
            );
        }
    }
}
