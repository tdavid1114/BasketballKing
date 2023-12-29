using AutoMapper;
using AutoMapper.Internal;
using BK_Server.DTO;
using BK_Server.Models;
using BK_Server.Repositories;
using BK_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BK_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpPost("getMyPlayers")]
        public async Task<ActionResult<GetPlayerDTO>> getMyPlayers([FromBody] sbyte teamid)
        {
            var myPlayers = await playerService.getMyPlayers(teamid);
            return Ok(myPlayers);
        }

        [HttpPut("updatePlayingStatus")]
        public async Task<ActionResult<bool>> updatePlayingStatus([FromBody] UpdatePlayerDTO playerDTO)
        {
            var result = await playerService.updatePlayingStatus(playerDTO);
            return Ok(result);
        }

        [HttpPost("requestPlayerAttributeUpdate")]
        public async Task<ActionResult<bool>> requestPlayerAttributeUpdate([FromBody] UpgradeDTO upgrade)
        {
            var result = await playerService.requestPlayerAttributeUpdate(upgrade);
            return Ok(result);
        }

        [HttpPut("purchasePlayerAttributeUpdate")]
        public async Task<ActionResult<bool>> purchasePlayerAttributeUpdate([FromBody] UpgradeDTO upgrade)
        {
            var result = await playerService.purchasePlayerAttributeUpdate(upgrade);
            return Ok(result);
        }
    }
}