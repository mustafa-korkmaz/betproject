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

        public DbSet<TestCodeFirstModel> TestsFirstModels { get; set; }
        //public DbSet<Market> Markets { get; set; }
        //public DbSet<MarketUser> MarketUsers { get; set; }
        //public DbSet<MarketUserIntegration> MarketUserIntegrations { get; set; }
        //public DbSet<IntegrationDetail> IntegrationDetails { get; set; }
        //public DbSet<Integration> Integrations { get; set; }

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
