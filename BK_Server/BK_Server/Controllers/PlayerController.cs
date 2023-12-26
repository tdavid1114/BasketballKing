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
        public ActionResult<GetPlayerDTO> getMyPlayers([FromBody] sbyte teamid)
        {
            var myPlayers = playerService.getMyPlayers(teamid);
            return Ok(myPlayers);
        }

        [HttpPut("updatePlayingStatus")]
        public IActionResult updatePlayingStatus([FromBody] UpdatePlayerDTO playerDTO)
        {
            var result = playerService.updatePlayingStatus(playerDTO);
            return Ok(result);
        }

        [HttpPost("requestPlayerAttributeUpdate")]
        public IActionResult requestPlayerAttributeUpdate([FromBody] UpgradeDTO upgrade)
        {
            var result = playerService.requestPlayerAttributeUpdate(upgrade);
            return Ok(result);
        }

        [HttpPut("purchasePlayerAttributeUpdate")]
        public IActionResult purchasePlayerAttributeUpdate([FromBody] UpgradeDTO upgrade)
        {
            var result = playerService.purchasePlayerAttributeUpdate(upgrade);
            return Ok(result);
        }
    }
}