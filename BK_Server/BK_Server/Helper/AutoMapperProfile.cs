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
            CreateMap<Player, GetPlayerDTO>()
                .ForMember(x => x.Strength, opt => opt.Ignore())
                .ForMember(x => x.Speed, opt => opt.Ignore())
                .ForMember(x => x.Shooting, opt => opt.Ignore())
                .ForMember(x => x.Finishing, opt => opt.Ignore())
                .ForMember(x => x.Playmaking, opt => opt.Ignore())
                .ForMember(x => x.Defence, opt => opt.Ignore())
                .ForMember(x => x.Blocking, opt => opt.Ignore())
                .ForMember(x => x.Rebounding, opt => opt.Ignore());
            CreateMap<UpgradeDTO, Upgrade>();
        }
    }
}