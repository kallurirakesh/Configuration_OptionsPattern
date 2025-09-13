namespace Configuration_OptionsPattern.Options
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
    }

    public class EmailApiSettings
    {
        public string Endpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }

    public class JobSettings
    {
        public int IntervalSeconds { get; set; }
        public bool Enabled { get; set; }
    }
}