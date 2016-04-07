using System.Collections.Generic;
using Common.Enumerations;

namespace DTO
{
    public class League
    {
        public int Id { get; set; }

        public int CategoryId { get; set; } // foreign key 

        public int CountryId { get; set; } // foreign key 

        public string Name { get; set; }

        public string Desc { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Team> Teams { get; set; } // 1=>n relation

    }
}
