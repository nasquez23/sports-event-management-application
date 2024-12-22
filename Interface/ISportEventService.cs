using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;

namespace SportsEvent.Service.Interface
{
    public interface ISportEventService
    {
        List<SportEvent> GetAllSportEvents();
        
        SportEvent GetSportEvent(Guid? id);
        
        void CreateSportEvent(SportEvent sportEvent);
        
        void UpdateSportEvent(SportEvent sportEvent);
        
        void DeleteSportEvent(Guid id);
    }
}