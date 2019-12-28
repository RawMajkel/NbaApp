﻿using Microsoft.AspNetCore.Mvc;
using NbaApp.Persistance;
using NbaApp.Services;

namespace NbaApp.Web.Controllers
{
    public class StandingsController : BaseController
    {
        public StandingsController(ApiService apiService) : base(apiService)
        {

        }
    }
}
