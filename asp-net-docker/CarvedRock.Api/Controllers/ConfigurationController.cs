using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarvedRock.Api.Controllers
{
    [Route("api/config")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRoot _configration;
        private readonly PositionOptions _options;
        private readonly LoggingOptions _loggingsOptions;

        public ConfigurationController(IConfiguration configration, IOptions<PositionOptions> options, IOptions<LoggingOptions> logging)
        {
            this._configration = configration as IConfigurationRoot;
            _options = options.Value;
            _loggingsOptions = logging.Value;
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

        [HttpGet("position")]
        public async Task<ActionResult<PositionOptions>> GetConfigs()
        {
            await Task.CompletedTask;
            return _options;
        }

        [HttpGet("logging")]
        public async Task<ActionResult<LoggingOptions>> GetLogging()
        {
            await Task.CompletedTask;
            return _loggingsOptions;
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