using System.ComponentModel.DataAnnotations;
using Common.Enumerations;

namespace DAL.Models
{
    /// <summary>
    /// db entity =>  dbo.team
    /// </summary>
    public class Team
    {
        public Team()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        public int LeagueId { get; set; } // foreign key 
        public virtual League League { get; set; } // navigation property

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

    }
}
