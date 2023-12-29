using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IUpgradeRepository
    {
        Task<bool> addPlayerUpgradeRequest(Upgrade upgrade);

        Task<Upgrade> getUpgrade(short playerid, string attribute);

        Task<List<Upgrade>> getActiveUpgradesByPlayer(short playerid);

        Task<bool> SaveAsync();

        Task<bool> updateUpgrade(Upgrade upgrade);
    }
}