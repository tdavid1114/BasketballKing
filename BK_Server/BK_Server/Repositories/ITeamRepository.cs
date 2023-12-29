using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> getMyTeam(sbyte teamid);

        Task<double> getTeamMoney(sbyte teamid);

        Task<bool> updateMoney(Team team);
    }
}