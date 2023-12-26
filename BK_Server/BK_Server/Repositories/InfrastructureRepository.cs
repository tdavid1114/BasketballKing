using BK_Server.Models;

namespace BK_Server.Repositories
{
    public class InfrastructureRepository : IInfrastructureRepository
    {
        private readonly BasketballkingContext context;

        public InfrastructureRepository(BasketballkingContext context)
        {
            this.context = context;
        }

        public Infrastructure getInfrastructure(sbyte teamid)
        {
            return context.Set<Infrastructure>().Where(x => x.Id == teamid).FirstOrDefault();
        }
    }
}