using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IPlayerRepository
    {
        IQueryable<Player> getMarketPlayers();

        IQueryable<Player> getMyPlayers(sbyte teamid);

        //bool UpdatePlayingStatus(short playerid, sbyte status);
        bool updatePlayingStatus(Player player);

        Player getMyPlayer(short playerid);
    }
}