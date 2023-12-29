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

        public async Task<List<Player>> getMarketPlayers()
        {
            return await playerRepository.getMarketPlayers();
        }

        public async Task<List<GetPlayerDTO>> getMyPlayers(sbyte teamid)
        {
            List<Player> players = await playerRepository.getMyPlayers(teamid);
            List<GetPlayerDTO> playersDto = new List<GetPlayerDTO>();

            foreach (var player in players)
            {
                List<Upgrade> upgrades = await upgradeRepository.getActiveUpgradesByPlayer(player.Playerid);
                var playerDTO = mapper.Map<GetPlayerDTO>(player);
                var foundUpgrade = upgrades.Where(x => x.Playerid == playerDTO.Playerid);
                playerDTO.Strength = new Tuple<sbyte, DateTime, short>(
                    player.Strength,
                    foundUpgrade.Where(x => x.Attribute == "Strength").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Strength").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Speed = new Tuple<sbyte, DateTime, short>(
                    player.Speed,
                    foundUpgrade.Where(x => x.Attribute == "Speed").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Speed").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Shooting = new Tuple<sbyte, DateTime, short>(
                    player.Shooting,
                    foundUpgrade.Where(x => x.Attribute == "Shooting").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Shooting").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Finishing = new Tuple<sbyte, DateTime, short>(
                    player.Finishing,
                    foundUpgrade.Where(x => x.Attribute == "Finishing").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Finishing").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Playmaking = new Tuple<sbyte, DateTime, short>(
                    player.Playmaking,
                    foundUpgrade.Where(x => x.Attribute == "Playmaking").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Playmaking").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Defence = new Tuple<sbyte, DateTime, short>(
                    player.Defence,
                    foundUpgrade.Where(x => x.Attribute == "Defence").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Defence").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Blocking = new Tuple<sbyte, DateTime, short>(
                    player.Blocking,
                    foundUpgrade.Where(x => x.Attribute == "Blocking").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Blocking").Select(x => x.Cost).FirstOrDefault()
                    );
                playerDTO.Rebounding = new Tuple<sbyte, DateTime, short>(
                    player.Rebounding,
                    foundUpgrade.Where(x => x.Attribute == "Rebounding").Select(x => x.Expirydate).FirstOrDefault(),
                    foundUpgrade.Where(x => x.Attribute == "Rebounding").Select(x => x.Cost).FirstOrDefault()
                    );

                playersDto.Add(playerDTO);
            }
            return playersDto;
        }

        public async Task<bool> updatePlayingStatus(UpdatePlayerDTO playerDTO)
        {
            Player player = await playerRepository.getMyPlayer(playerDTO.Playerid);
            if (player.IsInjured == 0)
            {
                player.IsStarter = playerDTO.IsStarter;
                return await playerRepository.updatePlayingStatus(player);
            }
            return false;
        }

        public async Task<bool> purchasePlayerAttributeUpdate(UpgradeDTO upgradeDTO)
        {
            Upgrade upgrade = await upgradeRepository.getUpgrade(upgradeDTO.Playerid, upgradeDTO.Attribute);
            if (await teamService.isMoneyEnough(upgrade.Teamid, upgrade.Cost))
            {
                upgrade.Expired = 1;
                return await upgradeRepository.updateUpgrade(upgrade) && await teamService.updateMoney(upgrade.Teamid, upgrade.Cost);
            }
            return false;
        }

        public async Task<bool> requestPlayerAttributeUpdate(UpgradeDTO upgradeDTO)
        {
            Player player = await playerRepository.getMyPlayer(upgradeDTO.Playerid);
            sbyte attributeLevel = (sbyte)player.GetType().GetProperty(upgradeDTO.Attribute).GetValue(player);
            sbyte gymLevel = (await infrastructureRepository.getInfrastructure(player.Teamid)).Gym;
            upgradeDTO.Expirydate = UpgradeTimeAndMoney.calculateTime(attributeLevel, gymLevel);
            upgradeDTO.Cost = UpgradeTimeAndMoney.calculateCost(attributeLevel, gymLevel);
            Upgrade upgrade = mapper.Map<Upgrade>(upgradeDTO);
            return await upgradeRepository.addPlayerUpgradeRequest(upgrade);
        }
    }
}