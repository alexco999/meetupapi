using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MeetupAPI.Controllers
{
    [Route("config")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpOptions("reload")]
        public ActionResult Reload()
        {
            try
            {
                ((IConfigurationRoot)_configuration).Reload();
                return Ok();
            }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            catch (Exception e)
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            {
                return StatusCode(500);
            }
        }
    }
}
