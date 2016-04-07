using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.league
    /// </summary>
    public class League
    {
        public League()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        public int CategoryId { get; set; } // foreign key 
        public virtual Category Category { get; set; } // navigation property

        public int CountryId { get; set; } // foreign key 
        public virtual Country Country { get; set; } // navigation property

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<Team> Teams { get; set; } // 1=>n relation

    }
}
