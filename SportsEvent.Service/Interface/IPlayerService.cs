using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain.Domain;

namespace SportsEvent.Service.Interface
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();

        Player GetPlayer(Guid? id);

        void AddPlayer(Player player);

        void UpdatePlayer(Player player);
        
        void DeletePlayer(Guid id);
    }
}