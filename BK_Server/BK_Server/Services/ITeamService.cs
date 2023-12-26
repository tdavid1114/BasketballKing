using BK_Server.Models;

namespace BK_Server.Services
{
    public interface ITeamService
    {
        bool isMoneyEnough(sbyte teamid, short cost);

        Team getMyTeam(sbyte teamid);

        bool updateMoney(sbyte teamid, short cost);
    }
}