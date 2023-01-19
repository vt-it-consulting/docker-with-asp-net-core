namespace CarvedRock.Api.Config
{
    public class LoggingOptions
    {
        public const string Position = "Logging";

        public string Environment { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string Lifetime { get; set; }
    }
}