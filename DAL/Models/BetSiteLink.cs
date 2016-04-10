
namespace DAL.Models
{
    public class BetSiteLink
    {
        public int Id { get; set; }

        public int BetSiteId { get; set; } // foreign key 
        public virtual BetSite BetSite { get; set; } // navigation property

        public int CountryId { get; set; } // foreign key 
        public virtual Country Country { get; set; } // navigation property

        public int CategoryId { get; set; } // foreign key 
        public virtual Category Category { get; set; } // navigation property

        public string Url { get; set; } //main url +  url 

    }
}
