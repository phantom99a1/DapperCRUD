using Domain.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Persistence.Options;

namespace Persistence.Providers
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly DatabaseConnectionOptions _options;

        public SqlConnectionProvider(IOptions<DatabaseConnectionOptions> options)
        {
            _options = options.Value;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_options.SqlConnection);
        }
    }
}
