using Microsoft.AspNetCore.Mvc;

namespace ToursApi.Controllers
{
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult ItWorks()
        {
            return Ok(new
            {
                DoesItWork = "Yes",
                AppName = "ToursApi",
                Dev = "Enea",
                Hotel = "Trivago"
            });
        }
    }
}