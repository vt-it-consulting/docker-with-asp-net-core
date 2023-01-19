using System;

namespace CarvedRock.Api.Config
{
    public class PositionOptions
    {
        public const string Position = "Position";

        public string Title { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string Db { get; set; } = String.Empty;
    }
}