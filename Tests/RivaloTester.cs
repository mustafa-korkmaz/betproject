using System.Collections.Generic;
using System.Threading.Tasks;
using Business.WebApi.Parsers;
using DAL.DataAccess;
using DTO;

namespace Tests
{
    public class RivaloTester : BetSiteTester, IBetSiteTester
    {
        private readonly RivaloParser _parser;
        private readonly BetSite _rivalo;

        private readonly BetSiteDataAccess _dataAccess = new BetSiteDataAccess();

        public RivaloTester()
        {
            _rivalo = _dataAccess.GetBetSiteDetails("Rivalo");
            _parser = new RivaloParser(_rivalo);
        }

        private IEnumerable<BetSiteLink> GetBetSiteLinks()
        {
            return _dataAccess.GetBetSiteLinks(_rivalo.Id);
        }

        private IEnumerable<BetSiteEvent> GetAllEvents(string eventsUrl)
        {
            return _parser.GetBetSiteEvents(eventsUrl);
        }

        /// <summary>
        ///  start testing operations for rivalo
        /// </summary>
        public async void StartTesting()
        {
            var rivaloLinks = GetBetSiteLinks();

            foreach (var link in rivaloLinks)
            {

                var completeUrl = link.BetSite.MainUrl + link.Url;

                var events = GetAllEvents(completeUrl);

                foreach (var betSiteEvent in events)
                {
                    // get event bets
                    var playerBets = await _parser.GetPlayerBets(betSiteEvent.BetSiteEventIdentifier);

                    // save event and player bets
                    _dataAccess.InsertBetSiteEvent(betSiteEvent);
                }
            }
        }
    }
}

