using BK_Server.Models;
using Microsoft.EntityFrameworkCore;
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

        public Task<Upgrade> getUpgrade(short playerid, string attribute)
        {
            return context.Set<Upgrade>().Where(x => x.Playerid == playerid && x.Attribute == attribute && x.Expired == 0).FirstOrDefaultAsync();
        }

        public Task<List<Upgrade>> getActiveUpgradesByPlayer(short playerid)
        {
            return context.Set<Upgrade>().Where(x => x.Playerid == playerid && x.Expired == 0).ToListAsync();
        }

        public async Task<bool> addPlayerUpgradeRequest(Upgrade upgrade)
        {
            await context.AddAsync(upgrade);
            return await SaveAsync();
        }

        public async Task<bool> updateUpgrade(Upgrade upgrade)
        {
            context.Update(upgrade);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0;
        }
    }
}