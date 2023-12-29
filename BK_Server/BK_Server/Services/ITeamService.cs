using BK_Server.Models;

namespace BK_Server.Services
{
    public interface ITeamService
    {
        Task<bool> isMoneyEnough(sbyte teamid, short cost);

        Task<Team> getMyTeam(sbyte teamid);

        Task<bool> updateMoney(sbyte teamid, short cost);
    }
}