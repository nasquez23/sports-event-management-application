using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;

namespace SportsEvent.Service.Interface
{
    public interface ITeamService
{
    Team GetTeam(Guid? teamId);

    List<Team> GetAllTeams();

    void CreateTeam(Team team);
    
    void UpdateTeam(Team team);
    
    void DeleteTeam(Guid teamId);
}
}