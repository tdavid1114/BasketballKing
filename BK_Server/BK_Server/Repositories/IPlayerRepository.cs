using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> getMarketPlayers();

        Task<List<Player>> getMyPlayers(sbyte teamid);

        //bool UpdatePlayingStatus(short playerid, sbyte status);
        Task<bool> updatePlayingStatus(Player player);

        Task<Player> getMyPlayer(short playerid);
    }
}