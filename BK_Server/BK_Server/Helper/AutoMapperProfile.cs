using AutoMapper;
using BK_Server.DTO;
using BK_Server.Models;

namespace BK_Server.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdatePlayerDTO, Player>();
            CreateMap<Player, GetPlayerDTO>();
            CreateMap<UpgradeDTO, Upgrade>();
        }
    }
}