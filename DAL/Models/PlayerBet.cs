
namespace DAL.Models
{
    public class PlayerBet
    {
        public int Id { get; set; }

        public int PlayerId { get; set; } // foreign key 
        public virtual Player Player { get; set; } // navigation property

        public int BetSiteEventId { get; set; } // foreign key 
        public virtual BetSiteEvent BetSiteEvent { get; set; } // navigation property

        public int ThresholdScore { get; set; }
    }
}
