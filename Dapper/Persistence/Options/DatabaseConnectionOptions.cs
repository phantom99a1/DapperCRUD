namespace Persistence.Options
{
    public class DatabaseConnectionOptions
    {
        public const string DatabaseConnectionKey = "ConnectionStrings";

        public string SqlConnection { get; set; } = string.Empty;
    }
}
