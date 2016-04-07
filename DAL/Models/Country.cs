using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.country
    /// </summary>
    public class Country
    {
        public Country()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<League> Leagues { get; set; } // 1=>n relation

    }
}
