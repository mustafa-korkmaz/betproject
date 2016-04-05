using DAL.Models;

namespace DAL.Configuration
{
    public class ContextCreator
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public void CreateDb()
        { // this insertion will trigger db schema creation
          //TestCodeFirstModel model = _db.TestsFirstModels.Single(p => p.Name == "helloworld");
            var user = new ApplicationUser() { UserName = "m.korkmaz@outlook.com", Email = "m.korkmaz@outlook.com" };

            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
