using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using SportsEvent.Domain.Domain;
using SportsEvent.Domain.Identity;
using System.Net.Mail;
using System.Net.Sockets;


namespace SportsEventApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<SportsEventApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<SportEvent> SportEvents { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set;}

        public virtual DbSet<Order> Orders { get; set; }  
        
        public virtual DbSet<TicketInOrder> TicketInOrders { get; set;}

        public virtual DbSet<TicketInShoppingCart> TicketInShoppingCarts { get; set; }

        public virtual DbSet<SportsEvent.Domain.EmailMessage> EmailMessages { get; set; }

    }
}
