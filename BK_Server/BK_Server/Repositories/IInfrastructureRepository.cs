using BK_Server.Models;

namespace BK_Server.Repositories
{
    public interface IInfrastructureRepository
    {
        Infrastructure getInfrastructure(sbyte teamid);
    }
}