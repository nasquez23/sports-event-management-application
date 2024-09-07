using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Identity;
using SportsEvent.Repository.Interface;
using SportsEventApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext context;
        private DbSet<SportsEventApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<SportsEventApplicationUser>();
        }


        public void Delete(SportsEventApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public  SportsEventApplicationUser Get(string? id)
        {
            return entities
               .Include(z => z.ShoppingCart)
               .Include("ShoppingCart.TicketsInShoppingCarts")
               .Include("ShoppingCart.TicketsInShoppingCarts.Ticket")
               .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<SportsEventApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(SportsEventApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(SportsEventApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
