using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IInfrastructureRepository
    {
        Task<Infrastructure> getInfrastructure(sbyte teamid);
    }
}