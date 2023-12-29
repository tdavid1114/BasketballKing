using BK_Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BK_Server.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BasketballkingContext context;

        public PlayerRepository(BasketballkingContext context)
        {
            this.context = context;
        }

        public Task<List<Player>> getMarketPlayers()
        {
            return context.Set<Player>().ToListAsync();
        }

        public Task<List<Player>> getMyPlayers(sbyte teamid)
        {
            return context.Set<Player>().Where(x => x.Teamid == teamid).ToListAsync();
        }

        public Task<Player> getMyPlayer(short playerid)
        {
            return context.Set<Player>().Where(x => x.Playerid == playerid).FirstOrDefaultAsync();
        }

        public async Task<bool> updatePlayingStatus(Player player)
        {
            context.Update(player);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0;
        }
    }
}