using Common.Enumerations;

namespace DAL.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public int EventId { get; set; } // foreign key 
        public virtual Event Event { get; set; } // navigation property

        public BettingType Type { get; set; }

    }
}
