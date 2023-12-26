using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IUpgradeRepository
    {
        bool addPlayerUpgradeRequest(Upgrade upgrade);

        Upgrade getUpgrade(short playerid, string attribute);

        IQueryable<Upgrade> GetActiveUpgrades();

        bool Save();

        bool updateUpgrade(Upgrade upgrade);
    }
}