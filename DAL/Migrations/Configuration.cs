using System.Data.Entity.Migrations;
using DAL.Models;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        /// <summary>
        ///  This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">bet project db context</param>
        protected override void Seed(ApplicationDbContext context)
        {
            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data.

            context.BetSites.AddOrUpdate(
           p => new { p.Name, p.Desc, p.MainUrl },
           new BetSite { Name = "Rivalo", Desc = "Rivalo.com", MainUrl = "https://www.rivalo.com" },
            new BetSite { Name = "Tempobet", Desc = "Tempobet.com", MainUrl = "https://www.tempobet.com" }
         );

            context.Countries.AddOrUpdate(
              p => new { p.Name, p.Desc },
              new Country { Name = "ABD", Desc = "ABD y ait tüm ligler" },
              new Country { Name = "Türkiye", Desc = "TR ye  ait tüm ligler" }
            );

            context.Categories.AddOrUpdate(
            p => new { p.Name, p.Desc },
            new Category { Name = "Spor", Desc = "Tüm Sporlar" },
            new Category { Name = "Basketbol", Desc = "Basketbol", ParentId = 1 }
          );

            context.Leagues.AddOrUpdate(
               p => new { p.Name, p.Desc, p.CategoryId, p.Country },
               new League { Name = "NBA", Desc = "ABD Ulusal basketbol ligi", CategoryId = 2, CountryId = 1 },
               new League { Name = "TBL Erkekler", Desc = "Türkiye Erkekler Basketbol Ligi", CategoryId = 2, CountryId = 2 }
             );

            context.Teams.AddOrUpdate(
            p => new { p.Name, p.Desc, p.LeagueId },
            new Team { Name = "Cleveland Cavaliers", Desc = " Cleveland Cavaliers basketbol takımı", LeagueId = 1 },
            new Team { Name = "Fenerbahçe Ülker", Desc = "FB basketbol takımı", LeagueId = 2 }
          );

            context.Players.AddOrUpdate(
             p => new { p.Name, p.TeamId },
                 new Player { Name = "LeBron James", TeamId = 1 },
                 new Player { Name = "Kyrie Irving", TeamId = 1 },
                 new Player { Name = "Kevin Love", TeamId = 1 },
                 new Player { Name = "Barış Hersek", TeamId = 2 },
                 new Player { Name = "Bogdan Bogdanovic", TeamId = 2 },
                 new Player { Name = "Boby Dixon", TeamId = 2 },
                 new Player { Name = "Jan Vesely", TeamId = 2 }
            );

        }
    }
}
