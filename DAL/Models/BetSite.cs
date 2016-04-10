using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.betsites
    /// </summary>
    public class BetSite
    {
        public BetSite()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [MaxLength(100)]
        [Required]
        public string MainUrl { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<BetSiteEvent> BetSiteEvents { get; set; } // 1=>n relation

        public virtual ICollection<BetSiteLink> BetSiteLinks { get; set; } // 1=>n relation

    }
}
