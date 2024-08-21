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
    public class SportEventService : ISportEventService
    {
        private readonly IRepository<SportEvent> _sportEventRepository;

        public SportEventService(IRepository<SportEvent> sportEventRepository)
        {
            _sportEventRepository = sportEventRepository;
        }

        public SportEvent GetSportEvent(Guid? sportEventId)
        {
            return _sportEventRepository.Get(sportEventId);
        }

        public List<SportEvent> GetAllSportEvents()
        {
            return _sportEventRepository.GetAll().ToList();
        }

        public void CreateSportEvent(SportEvent sportEvent)
        {
            _sportEventRepository.Insert(sportEvent);
        }

        public void UpdateSportEvent(SportEvent sportEvent)
        {
            _sportEventRepository.Update(sportEvent);
        }

        public void DeleteSportEvent(Guid sportEventId)
        {
            _sportEventRepository.Delete(_sportEventRepository.Get(sportEventId));
        }
    }    
}