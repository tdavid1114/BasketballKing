using BK_Server.DTO;
using BK_Server.Models;

namespace BK_Server.Services
{
    public interface IPlayerService
    {
        Task<List<Player>> getMarketPlayers();

        Task<List<GetPlayerDTO>> getMyPlayers(sbyte teamid);

        Task<bool> purchasePlayerAttributeUpdate(UpgradeDTO upgradeDTO);

        Task<bool> requestPlayerAttributeUpdate(UpgradeDTO upgradeDTO);

        Task<bool> updatePlayingStatus(UpdatePlayerDTO playerDTO);
    }
}