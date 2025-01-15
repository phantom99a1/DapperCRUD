using Microsoft.Data.SqlClient;

namespace Domain.Persistence
{
    public interface ISqlConnectionProvider
    {
        SqlConnection GetConnection();
    }
}
