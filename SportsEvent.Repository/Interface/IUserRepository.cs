using SportsEvent.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<SportsEventApplicationUser> GetAll();
        SportsEventApplicationUser  Get(string? id);
        void Insert(SportsEventApplicationUser entity);
        void Update(SportsEventApplicationUser entity);
        void Delete(SportsEventApplicationUser entity);


    }
}
