
namespace DTO
{
    public class PlayerBet
    {
        public int Id { get; set; }

        public int PlayerId { get; set; } // foreign key 
        public virtual Player Player { get; set; } // navigation property

        public int BetId { get; set; } // foreign key 
        public virtual Bet Bet { get; set; } // navigation property

        public int ThresholdScore { get; set; }
    }
}
