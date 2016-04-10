using System;
using System.Collections.Generic;

namespace Business.WebApi.Tester
{
    public class BetSiteTester
    {
        public int MinutesPerRequest { get; set; }

        public BetSiteTester()
        {
            MinutesPerRequest = 5; //default 5 min wait per requests
        }
    }
}

