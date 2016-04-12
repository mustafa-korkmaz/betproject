using System;

namespace DTO
{
    public class BotStatics
    {
        public int Id { get; set; }

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        public string RequestUrl { get; set; }

        public int ResponseCode { get; set; }

        public string ResponseText { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
