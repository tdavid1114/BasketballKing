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

        public bool isMoneyEnough(sbyte teamid, short cost)
        {
            return teamRepository.getTeamMoney(teamid) > cost ? true : false;
        }

        public Team getMyTeam(sbyte teamid)
        {
            return teamRepository.getMyTeam(teamid);
        }

        public bool updateMoney(sbyte teamid, short cost)
        {
            Team team = teamRepository.getMyTeam(teamid);
            if (team.Money > cost)
            {
                team.Money -= cost;
                return teamRepository.updateMoney(team);
            }
            else
            {
                return false;
            }
        }
    }
}