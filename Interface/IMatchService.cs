using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;

namespace SportsEvent.Service.Interface
{
    public interface IMatchService
    {
        Match GetMatch(Guid? matchId);

        List<Match> GetAllMatches();

        void AddMatch(Match match);

        void UpdateMatch(Match match);
        
        void DeleteMatch(Guid matchId);
    }
}