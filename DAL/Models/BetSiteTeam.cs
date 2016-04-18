using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.betsiteteams
    /// </summary>
    public class BetSiteTeam
    {
        public int Id { get; set; }

        public int TeamId { get; set; } // foreign key 
        public virtual Team Team { get; set; } // navigation property

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
