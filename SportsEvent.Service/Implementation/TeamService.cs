using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;

namespace SportsEvent.Service.Implementation 
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamService(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team GetTeam(Guid? teamId)
        {
            return _teamRepository.Get(teamId);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepository.GetAll().ToList();
        }

        public void CreateTeam(Team team)
        {
            _teamRepository.Insert(team);
        }

        public void UpdateTeam(Team team)
        {
            _teamRepository.Update(team);
        }

        public void DeleteTeam(Guid teamId)
        {
            _teamRepository.Delete(_teamRepository.Get(teamId));
        }
    }    
}