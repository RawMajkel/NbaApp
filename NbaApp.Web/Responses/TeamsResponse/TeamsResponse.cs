﻿using System;
using System.Collections.Generic;

namespace NbaApp.Web.Responses
{
    public class TeamsResponse
    {
        public List<TeamResponse> Teams { get; set; }
        public EntityInfo Meta { get; set; }

        public TeamsResponse()
        {

        }
    }
}
