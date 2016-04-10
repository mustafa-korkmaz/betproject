using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccess;
using DTO;

namespace Business.WebApi.Client
{
    /// <summary>
    /// logs request and responses
    /// </summary>
    public class Logger
    {
        public static Logger Instance { get; } = new Logger();
        private readonly BotStaticsDataAccess _dataAccess = new BotStaticsDataAccess();

        private Logger()
        {
            //initialize
        }
        public void Log(BotStatics statics)
        {
            _dataAccess.InsertBotStatics(statics);
        }
    }
}

