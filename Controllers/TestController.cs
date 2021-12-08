﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToursApi.Controllers
{
    [Route("api/test")]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult ItWorks()
        {
            return Ok(new
            {
                DoesItWork = "Yes",
                AppName = "Ku do shkojmë?",
                Dev = "Enea",
                Hotel = "Trivago"
            });
        }
    }
}