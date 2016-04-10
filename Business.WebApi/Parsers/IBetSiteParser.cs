using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace Business.WebApi.Parsers
{
    public interface IBetSiteParser
    {
        IEnumerable<BetSiteEvent> GetBetSiteEvents(string url);

        Task<IEnumerable<PlayerBet>> GetPlayerBets(string betSiteEventIdentifier);
    }
}
