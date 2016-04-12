using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class BotStatics
    {
        public BotStatics()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        [MaxLength(2048)]
        public string RequestUrl { get; set; }

        public int ResponseCode { get; set; } // http status response  code

        public string ResponseText { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
