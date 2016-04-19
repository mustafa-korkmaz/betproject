using System;
using System.Collections;
using System.Collections.Generic;
using DTO;

namespace Business.WebApi
{
    public class BaseParser
    {
        /// <summary>
        /// single betSite event update operation
        /// </summary>
        /// <param name="betSiteEvent"></param>
        public void UpdateEvent(BetSiteEvent betSiteEvent)
        {
            //todo: update or insert events and betsiteEvents table

        }

        /// <summary>
        /// multiple betSite events update operation
        /// </summary>
        /// <param name="betSiteEvents"></param>
        public void UpdateEvents(IEnumerable<BetSiteEvent> betSiteEvents)
        {
            //todo: update or insert events and betsiteEvents table

        }

        /// <summary>
        /// multiple playerBets update operation
        /// </summary>
        /// <param name="playerBet"></param>
        public void UpdatePlayerBet(PlayerBet playerBet)
        {
            //todo: update a player bet

        }

        /// <summary>
        /// single playerBet update operation
        /// </summary>
        /// <param name="playerBets"></param>
        public void UpdatePlayerBets(IEnumerable<PlayerBet> playerBets)
        {
            //todo: update a player bet

        }

        /// <summary>
        /// returns  event identifier of related bet site event
        /// </summary>
        /// <param name="eventIdIncludedText"></param>
        /// <param name="regexMatchText"></param>
        /// <returns></returns>
        protected string GetEventId(string eventIdIncludedText, string regexMatchText)
        {
            string eventId = String.Empty;

            return eventId;
        }

        /// <summary>
        /// returns  event teams of related bet site event
        /// </summary>
        /// <param name="teamsIncludedText"></param>
        /// <param name="regexMatchText"></param>
        /// <returns></returns>
        protected Team[] GetEventTeams(string teamsIncludedText, string regexMatchText)
        {
            var teams = new Team[2];

            return teams;
        }

        /// <summary>
        ///  returns  event start time of related bet site event
        /// </summary>
        /// <param name="startTimeIncludedText"></param>
        /// <param name="regexMatchText"></param>
        /// <returns></returns>
        protected DateTime GetEventStartTime(string startTimeIncludedText, string regexMatchText)
        {
            var eventStartTime = DateTime.Now;

            return eventStartTime;
        }
    }
}
