using AutoMapper;
using BK_Server.DTO;
using BK_Server.Models;
using BK_Server.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection;

namespace BK_Server.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IInfrastructureRepository infrastructureRepository;
        private readonly IUpgradeRepository upgradeRepository;
        private readonly IMapper mapper;
        private readonly ITeamService teamService;

        public PlayerService(IPlayerRepository playerRepository, IInfrastructureRepository infrastructureRepository, IUpgradeRepository upgradeRepository, IMapper mapper, ITeamService teamService)
        {
            this.playerRepository = playerRepository;
            this.upgradeRepository = upgradeRepository;
            this.infrastructureRepository = infrastructureRepository;
            this.mapper = mapper;
            this.teamService = teamService;
        }

        public IQueryable<Player> getMarketPlayers()
        {
            return playerRepository.getMarketPlayers();
        }

        public List<GetPlayerDTO> getMyPlayers(sbyte teamid)
        {
            List<Player> players = playerRepository.getMyPlayers(teamid).ToList();
            List<Upgrade> upgrades = upgradeRepository.GetActiveUpgrades().ToList();
            List<GetPlayerDTO> playersDto = new List<GetPlayerDTO>();

            foreach (var player in players)
            {
                var GetPlayerDTO = mapper.Map<GetPlayerDTO>(player);
                var foundUpgrade = upgrades.Find(x => x.Playerid == GetPlayerDTO.Playerid);
                if (foundUpgrade != null)
                {
                    GetPlayerDTO.Expirydate = foundUpgrade.Expirydate;
                }
                playersDto.Add(GetPlayerDTO);
            }
            return playersDto;
        }

        public bool updatePlayingStatus(UpdatePlayerDTO playerDTO)
        {
            Player player = playerRepository.getMyPlayer(playerDTO.Playerid);
            if (player.IsInjured == 0)
            {
                player.IsStarter = playerDTO.IsStarter;
                return playerRepository.updatePlayingStatus(player);
            }
            return false;
        }

        public bool purchasePlayerAttributeUpdate(UpgradeDTO upgradeDTO)
        {
            Player player = playerRepository.getMyPlayer(upgradeDTO.Playerid);
            sbyte attributeLevel = (sbyte)player.GetType().GetProperty(upgradeDTO.Attribute).GetValue(player);
            sbyte gymLevel = infrastructureRepository.getInfrastructure(player.Teamid).Gym;
            short cost = UpgradeTimeAndMoney.calculateMoney(attributeLevel, gymLevel);
            if (teamService.isMoneyEnough(player.Teamid, cost))
            {
                Upgrade upgrade = upgradeRepository.getUpgrade(upgradeDTO.Playerid, upgradeDTO.Attribute);
                upgrade.Expired = 1;
                return upgradeRepository.updateUpgrade(upgrade) && teamService.updateMoney(player.Teamid, cost);
            }
            else
            {
                return false;
            }
        }

        public bool requestPlayerAttributeUpdate(UpgradeDTO upgradeDTO)
        {
            Player player = playerRepository.getMyPlayer(upgradeDTO.Playerid);
            sbyte attributeLevel = (sbyte)player.GetType().GetProperty(upgradeDTO.Attribute).GetValue(player);
            sbyte gymLevel = infrastructureRepository.getInfrastructure(player.Teamid).Gym;
            DateTime expiryDate = UpgradeTimeAndMoney.calculateTime(attributeLevel, gymLevel);
            upgradeDTO.Expirydate = expiryDate;
            Upgrade upgrade = mapper.Map<Upgrade>(upgradeDTO);
            return upgradeRepository.addPlayerUpgradeRequest(upgrade);
        }
    }
}