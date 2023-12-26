using BK_Server.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace BK_Server.Repositories
{
    public class UpgradeRepository : IUpgradeRepository
    {
        private readonly BasketballkingContext context;

        public UpgradeRepository(BasketballkingContext context)
        {
            this.context = context;
        }

        public Upgrade getUpgrade(short playerid, string attribute)
        {
            return context.Set<Upgrade>().Where(x => x.Playerid == playerid && x.Attribute == attribute && x.Expired == 0).FirstOrDefault();
        }

        public IQueryable<Upgrade> GetActiveUpgrades()
        {
            return context.Set<Upgrade>().Where(x => x.Expired == 0);
        }

        public bool addPlayerUpgradeRequest(Upgrade upgrade)
        {
            context.Add(upgrade);
            return Save();
        }

        public bool updateUpgrade(Upgrade upgrade)
        {
            context.Update(upgrade);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}