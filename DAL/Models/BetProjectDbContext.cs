using System.Data.Entity;
using DAL.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<BetSite> BetSites { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PlayerBet> PlayerBets { get; set; }
        public DbSet<BotStatics> BotStatics { get; set; }
        public DbSet<BetSiteEvent> BetSiteEvents { get; set; }
        public DbSet<BetSiteLink> BetSiteLinks { get; set; }
        public DbSet<BetSitePlayer> BetSitePlayers { get; set; }
        public DbSet<BetSiteTeam> BetSiteTeams { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////one-to-many 
            //modelBuilder.Entity<MarketUser>()
            //            .HasRequired<Market>(m => m.Market)
            //            .WithMany(m => m.MarketUsers)
            //            .HasForeignKey(m => m.MarketId);

            //modelBuilder.Entity<MarketUserIntegration>()
            //         .HasRequired<MarketUser>(m => m.MarketUser)
            //         .WithMany(m => m.MarketUserIntegrations)
            //         .HasForeignKey(m => m.MarketUserId);

            //modelBuilder.Entity<MarketUserIntegration>()
            //      .HasRequired<Integration>(m => m.Integration)
            //      .WithMany(m => m.MarketUserIntegrations)
            //      .HasForeignKey(m => m.IntegrationId);

            //modelBuilder.Entity<IntegrationDetail>()
            //    .HasRequired<Integration>(m => m.Integration)
            //    .WithMany(m => m.IntegrationDetails)
            //    .HasForeignKey(m => m.IntegrationId);

        }

    }
}
