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

        public IQueryable<Player> getMarketPlayers()
        {
            return context.Set<Player>();
        }

        public IQueryable<Player> getMyPlayers(sbyte teamid)
        {
            return context.Set<Player>().Where(x => x.Teamid == teamid);
        }

        public Player getMyPlayer(short playerid)
        {
            return context.Set<Player>().Where(x => x.Playerid == playerid).FirstOrDefault();
        }

        public bool updatePlayingStatus(Player player)
        {
            context.Update(player);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}