using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    /// <summary>
    ///  bet site's  events
    /// </summary>
    public class BetSiteEvent
    {
        public int Id { get; set; }

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        [MaxLength(100)]
        [Required]
        public string BetSiteEventIdentifier { get; set; }  // eg: rivalo event id

        public int EventId { get; set; } // foreign key => bet project event id
        public virtual Event Event { get; set; } // navigation property

        [MaxLength(500)]
        public string Url { get; set; } //direct link to  bet site's event

        public virtual ICollection<PlayerBet> PlayerBets { get; set; } // 1=>n relation

    }
}
