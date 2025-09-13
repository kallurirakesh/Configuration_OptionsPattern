using Configuration_OptionsPattern.Options;
using Microsoft.Extensions.Options;

namespace Configuration_OptionsPattern.Services
{
    public interface IDatabaseService
    {
        string GetProvider();
        string GetConnectionString();
    }
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseSettings _settings;
        public DatabaseService(IOptions<DatabaseSettings> options)
        {
            _settings = options.Value;
        }
        public string GetProvider() => _settings.Provider;
        public string GetConnectionString() => _settings.ConnectionString;
    }

    public interface IEmailService
    {
        string GetEndpoint();
        string GetApiKey();
    }
    public class EmailService : IEmailService
    {
        private readonly EmailApiSettings _settings;
        public EmailService(IOptions<EmailApiSettings> options)
        {
            _settings = options.Value;
        }
        public string GetEndpoint() => _settings.Endpoint;
        public string GetApiKey() => _settings.ApiKey;
    }

    public interface IJobService
    {
        int GetInterval();
        bool IsEnabled();
    }
    public class JobService : IJobService
    {
        private readonly JobSettings _settings;
        public JobService(IOptions<JobSettings> options)
        {
            _settings = options.Value;
        }
        public int GetInterval() => _settings.IntervalSeconds;
        public bool IsEnabled() => _settings.Enabled;
    }
}