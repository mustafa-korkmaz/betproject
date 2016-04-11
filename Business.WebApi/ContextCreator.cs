using DTO;

namespace Business.WebApi
{
    public class ContextCreator
    {
        public void CreateDb()
        { // this insertion will trigger db schema creation
            new DAL.Configuration.ContextCreator().CreateDb();
        }

        public BetSite GetBetSite()
        {
            return new DAL.DataAccess.BetSiteDataAccess().GetBetSiteDetails("Rivalo");
        }
    }
}
