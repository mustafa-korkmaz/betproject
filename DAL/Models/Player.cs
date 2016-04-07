using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.player
    /// </summary>
    public class Player
    {
        public Player()
        {
            Status = Status.Active;
            Condition=Condition.Ok;
        }

        public int Id { get; set; }

        public int TeamId { get; set; } // foreign key 
        public virtual Team Team { get; set; } // navigation property

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Condition Condition { get; set; }

    }
}
