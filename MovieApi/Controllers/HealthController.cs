using System;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
	[Route("health")]
	public class HealthController : BaseController<HealthController>
	{
		public HealthController(ILogger<HealthController> logger) : base(logger)
		{
		}

        [HttpGet]
        public IActionResult Health()
        {
            return Ok("healthy");
        }
    }
}

