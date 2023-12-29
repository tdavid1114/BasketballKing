using BK_Server.Models;
using BK_Server.Repositories;

namespace BK_Server.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task<bool> isMoneyEnough(sbyte teamid, short cost)
        {
            return await teamRepository.getTeamMoney(teamid) > cost;
        }

        public async Task<Team> getMyTeam(sbyte teamid)
        {
            return await teamRepository.getMyTeam(teamid);
        }

        public async Task<bool> updateMoney(sbyte teamid, short cost)
        {
            Team team = await teamRepository.getMyTeam(teamid);
            if (team.Money > cost)
            {
                team.Money -= cost;
                return await teamRepository.updateMoney(team);
            }
            return false;
        }
    }
}