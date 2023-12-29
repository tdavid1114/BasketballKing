using BK_Server.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<double> getTeamMoney(sbyte teamid)
        {
            return (await context.Set<Team>().Where(x => x.Teamid == teamid).FirstOrDefaultAsync()).Money;
        }

        public Task<Team> getMyTeam(sbyte teamid)
        {
            return context.Set<Team>().Where(x => x.Teamid == teamid).FirstOrDefaultAsync();
        }

        public async Task<bool> updateMoney(Team team)
        {
            context.Update(team);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}