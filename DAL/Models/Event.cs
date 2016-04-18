using System;
using System.Collections.Generic;

namespace DAL.Models
{
    /// <summary>
    ///  bet project events 
    /// table name => dbo.events
    /// </summary>
    public class Event
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; } // foreign key 
        public virtual Team HomeTeam { get; set; } // navigation property

        public int AwayTeamId { get; set; } // foreign key 
        public virtual Team AwayTeam { get; set; } // navigation property

        public DateTime StartDateTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<BetSiteEvent> BetSiteEvents { get; set; } // 1=>n relation

    }
}
