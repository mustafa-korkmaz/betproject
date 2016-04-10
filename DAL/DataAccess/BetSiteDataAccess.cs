using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using BetSite = DTO.BetSite;
using BetSiteLink = DTO.BetSiteLink;
using BetSiteEvent = DTO.BetSiteEvent;

namespace DAL.DataAccess
{
    public class BetSiteDataAccess
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public BetSite GetBetSiteDetails(string betSiteName)
        {
            var site = new BetSite { Name = betSiteName };

            var betSite = _db.BetSites.Single(b => b.Name == betSiteName);

            site.Id = betSite.Id;
            site.MainUrl = betSite.MainUrl;

            return site;
        }

        public IEnumerable<BetSiteLink> GetBetSiteLinks(int betSiteId)
        {
            var query = _db.BetSiteLinks.Where(l => l.BetSiteId == betSiteId);

            var betSiteLinks = query.Select(p => new BetSiteLink
            {
                Url = p.Url,
                Id = p.Id,
                CategoryId = p.CategoryId,
                CountryId = p.CountryId,
                BetSiteId = p.BetSiteId,
                BetSite = new BetSite { Id = p.BetSiteId, MainUrl = p.BetSite.MainUrl }
            })
            .ToList();

            var result = MappingConfigurator.Mapper.Map<IEnumerable<BetSiteLink>>(betSiteLinks);

            return result;
        }

        public void InsertBetSiteEvent(BetSiteEvent betSiteEvent)
        {
            var entity = MappingConfigurator.Mapper.Map<Models.BetSiteEvent>(betSiteEvent);

            _db.BetSiteEvents.Add(entity);
            _db.SaveChangesAsync();

        }
    }
}
