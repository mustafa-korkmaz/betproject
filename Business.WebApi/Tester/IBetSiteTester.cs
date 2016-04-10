using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enumerations;
using DTO;

namespace Business.WebApi.Tester
{
    public interface IBetSiteTester
    {
        //IEnumerable<Event> GetAllEventsByUrl(string eventsUrl);

        ////  IEnumerable<Event> GetFilteredEvents(IEnumerable<Event> unfilteredEvents);

        //string GetEventId(Event _event);

        //IEnumerable<Bet> GetEventBets(BettingType bettingType, string eventId);

       Task StartTesting();
    }
}
