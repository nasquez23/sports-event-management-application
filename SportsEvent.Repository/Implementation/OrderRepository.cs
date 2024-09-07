using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Interface;
using SportsEventApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.TicketsInOrder)
                .Include(z => z.Owner)
                .Include("TicketsInOrder.Ticket")
                .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(z => z.TicketsInOrder)
                .Include(z => z.Owner)
                .Include("TicketsInOrder.Ticket")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }

       
    }
}
