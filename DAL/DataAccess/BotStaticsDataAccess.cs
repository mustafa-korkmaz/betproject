using System.Collections.Generic;
using System.Linq;
using DAL.Models;

using BotStatics = DTO.BotStatics;

namespace DAL.DataAccess
{
    public class BotStaticsDataAccess
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public void InsertBotStatics(BotStatics statics)
        {
            var entity = MappingConfigurator.Mapper.Map<Models.BotStatics>(statics);

            _db.BotStatics.Add(entity);
            //_db.SaveChangesAsync();
            _db.SaveChanges();
        }
    }
}
