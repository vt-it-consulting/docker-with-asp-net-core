using CarvedRock.Api.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Api.Controllers
{
    [Route("api/config")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRoot _configration;

        public ConfigurationController(IConfiguration configration)
        {
            this._configration = configration as IConfigurationRoot;
        }
        [HttpGet]
        public async Task<ActionResult<Config>> GetConfiguration()
        {
            var config = (_configration as IConfigurationRoot);
            var connectionString = config.GetConnectionString("Db");
            var simpleProperty = config.GetValue<string>("SimpleProperty");
            var nestedProp = config.GetValue<string>("Inventory:NestedProperty");

            await Task.CompletedTask;

            return new Config() { ConnectionString = connectionString, SimpleProperty = simpleProperty, NestedProperty = nestedProp };

        }
        [HttpGet("advanced")]
        public async Task<ActionResult<Config>> GetConfigurationAdvanced()
        {
            var dbgView = (_configration as IConfigurationRoot).GetDebugView();

            await Task.CompletedTask;

            return new Config() { AllString = dbgView };

        }
       
    }
}
