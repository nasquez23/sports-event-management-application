using System;
using System.Collections.Generic;
using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;

namespace SportsEvent.Service.Implementation
{
    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<SportEvent> _sportEventRepository;

        public MatchService(IRepository<Match> matchRepository, IRepository<SportEvent> sportEventRepository)
        {
            _matchRepository = matchRepository;
            _sportEventRepository = sportEventRepository;
        }

        public Match GetMatch(Guid? matchId)
        {
            return _matchRepository.Get(matchId);
        }

        public List<Match> GetAllMatches()
        {
            return _matchRepository.GetAll().ToList();
        }

        public void AddMatch(Match match)
        {
            match.SportEvent = _sportEventRepository.Get(match.SportEventId);
            _matchRepository.Insert(match);
        }

        public void UpdateMatch(Match match)
        {
            match.SportEvent = _sportEventRepository.Get(match.SportEventId);
            _matchRepository.Update(match);
        }

        public void DeleteMatch(Guid matchId)
        {
            _matchRepository.Delete(_matchRepository.Get(matchId));
        }
    }
}