using Configuration_OptionsPattern.Options;
using Configuration_OptionsPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace Configuration_OptionsPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigDemoController : ControllerBase
    {
        private readonly IDatabaseService _dbService;
        private readonly IEmailService _emailService;
        private readonly IJobService _jobService;
        public ConfigDemoController(IDatabaseService dbService, IEmailService emailService, IJobService jobService)
        {
            _dbService = dbService;
            _emailService = emailService;
            _jobService = jobService;
        }

        [HttpGet("db")]
        public IActionResult GetDbSettings() => Ok(new { Provider = _dbService.GetProvider(), ConnectionString = _dbService.GetConnectionString() });

        [HttpGet("email")]
        public IActionResult GetEmailSettings() => Ok(new { Endpoint = _emailService.GetEndpoint(), ApiKey = _emailService.GetApiKey() });

        [HttpGet("job")]
        public IActionResult GetJobSettings() => Ok(new { Interval = _jobService.GetInterval(), Enabled = _jobService.IsEnabled() });
    }
}