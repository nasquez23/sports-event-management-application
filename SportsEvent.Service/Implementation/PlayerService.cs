using System;
using System.Collections.Generic;
using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;

namespace SportsEvent.Service.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepository;
        private readonly IRepository<Team> _teamRepository;

        public PlayerService(IRepository<Player> playerRepository, IRepository<Team> teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        
        public List<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll().ToList();
        }

        public Player GetPlayer(Guid? playerId)
        {
            return _playerRepository.Get(playerId);
        }

        public void AddPlayer(Player player)
        {
            player.Team = _teamRepository.Get(player.TeamId);
            _playerRepository.Insert(player);
        }

        public void UpdatePlayer(Player player)
        {
            player.Team = _teamRepository.Get(player.TeamId);
            _playerRepository.Update(player);
        }

        public void DeletePlayer(Guid playerId)
        {
            _playerRepository.Delete(_playerRepository.Get(playerId));
        }
    }
}