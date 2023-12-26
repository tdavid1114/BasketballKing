using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface ITeamRepository
    {
        Team getMyTeam(sbyte teamid);

        double getTeamMoney(sbyte teamid);

        bool updateMoney(Team team);
    }
}