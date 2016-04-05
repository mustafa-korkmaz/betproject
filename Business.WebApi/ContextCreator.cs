namespace Business.WebApi
{
    public class ContextCreator
    {
        public void CreateDb()
        { // this insertion will trigger db schema creation
            new DAL.Configuration.ContextCreator().CreateDb();
        }
    }
}
