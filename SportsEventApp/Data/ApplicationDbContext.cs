using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsEvent.Domain.Domain;

namespace SportsEventApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SportsEvent.Domain.Domain.Player> Player { get; set; } = default!;
        public DbSet<SportsEvent.Domain.Domain.Team> Team { get; set; } = default!;
        public DbSet<SportsEvent.Domain.Domain.Match> Match { get; set; } = default!;
        public DbSet<SportsEvent.Domain.Domain.SportEvent> SportEvent { get; set; } = default!;
    }
}
