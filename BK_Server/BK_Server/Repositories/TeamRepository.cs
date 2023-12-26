using BK_Server.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BK_Server.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly BasketballkingContext context;

        public TeamRepository(BasketballkingContext context)
        {
            this.context = context;
        }

        public double getTeamMoney(sbyte teamid)
        {
            return context.Set<Team>().Where(x => x.Teamid == teamid).FirstOrDefault().Money;
        }

        public Team getMyTeam(sbyte teamid)
        {
            return context.Set<Team>().Where(x => x.Teamid == teamid).FirstOrDefault();
        }

        public bool updateMoney(Team team)
        {
            context.Update(team);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}