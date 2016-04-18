using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebApi.Parsers
{
    interface IEventParser
    {
        IEnumerable<BetSiteEvent> GetBetSiteEvents(string url);

        //void UpdateEvents(IEnumerable<BetSiteEvent> betSiteEvents);

        //Task<IEnumerable<PlayerBet>> GetPlayerBets(string betSiteEventIdentifier);
    }
}
