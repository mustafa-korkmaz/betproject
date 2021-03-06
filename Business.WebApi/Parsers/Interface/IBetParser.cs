﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebApi.Parsers.Interface
{
    interface IBetParser
    {
        Task<IEnumerable<PlayerBet>> GetPlayerBets(string betSiteEventIdentifier);
    }
}
