using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using Business.WebApi.Client;
using Common.Enumerations;
using WebClient = Business.WebApi.Client.WebClient;
using Business.WebApi.Parsers.Interface;

namespace Business.WebApi.Parsers
{
    /// <summary>
    ///  calss which includes parsing operations for rivalo.com
    /// </summary>
    public class RivaloParser : BaseBetsite, IEventParser, IBetParser, IOddsParser
    {
        private readonly HtmlParser _parser;
        private readonly WebClient _client;
        private readonly BetSite _rivalo;

        public RivaloParser(BetSite rivalo)
        {
            _parser = new HtmlParser();
            _client = WebClient.Instance;
            _client.BetSiteId = rivalo.Id;
            _rivalo = rivalo;
        }

        public IEnumerable<BetSiteEvent> GetBetSiteEvents(string url)
        {
            var betSiteEventList = new List<BetSiteEvent>();

            var clientRes = _client.GetResponseText(url);

            if (clientRes.HttpStatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var document = _parser.Parse(clientRes.ResponseData);

            var eventDivs = document.QuerySelectorAll("div[class='socialMediaLinks']");

            foreach (var eventdiv in eventDivs)
            {
                var betSiteEvent = GetBetSiteEvent(eventdiv.InnerHtml);

                if (betSiteEvent != null)
                {
                    betSiteEventList.Add(betSiteEvent);
                }
            }

            return betSiteEventList;
        }

        public async Task<IEnumerable<PlayerBet>> GetPlayerBets(string betSiteEventIdentifier)
        {
            string url = "/spring/complete";
            string completeUrl = _rivalo.MainUrl + url;

            Uri uri = new Uri(completeUrl);

            string requestParameterKey = "_";
            string requestParamaterValue = "program/specialBet/specialBetLayer2?eventId=" + betSiteEventIdentifier;

            var parameterDic = new Dictionary<string, string> { { requestParameterKey, requestParamaterValue } };

            var clientRes = await _client.PostAsync(uri, parameterDic);

            if (clientRes.HttpStatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var document = _parser.Parse(clientRes.ResponseData);

            return null;
        }

        private string GetRivaloEventId(string content)
        {
            Regex regex = new Regex(@"/e\d+");
            Match match = regex.Match(content);

            if (!match.Success)
            {
                return null;
            }

            string eventId = match.Value.Substring(2); // trim '/e'

            return eventId;
        }

        private BetSiteEvent GetBetSiteEvent(string htmlContent)
        {
            BetSiteEvent betSiteEvent = new BetSiteEvent();

            string eventIdentifier = GetRivaloEventId(htmlContent);

            if (eventIdentifier == null)
            {
                return null;
            }

            betSiteEvent.BetSiteEventIdentifier = eventIdentifier;
            //betSiteEvent.BetSite = _rivalo;
            betSiteEvent.BetSiteId = _rivalo.Id;
            betSiteEvent.EventId = 1;
            betSiteEvent.Url = "testUrl";

            return betSiteEvent;
        }
    }
}
