using BK_Server.DTO;
using BK_Server.Models;

namespace BK_Server.Services
{
    public interface IPlayerService
    {
        IQueryable<Player> getMarketPlayers();

        List<GetPlayerDTO> getMyPlayers(sbyte teamid);

        bool purchasePlayerAttributeUpdate(UpgradeDTO upgradeDTO);

        bool requestPlayerAttributeUpdate(UpgradeDTO upgradeDTO);

        bool updatePlayingStatus(UpdatePlayerDTO playerDTO);
    }
}