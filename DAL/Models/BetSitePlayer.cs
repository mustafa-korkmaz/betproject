using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.betsiteplayers
    /// </summary>
    public class BetSitePlayer
    {
        public int Id { get; set; }

        public int PlayerId { get; set; } // foreign key 
        public virtual Player Player { get; set; } // navigation property

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
